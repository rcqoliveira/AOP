using Castle.DynamicProxy;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace RC.AOP
{
    public class LoggingAsyncInterceptor : IInterceptor
    {
        private IInvocation invocation;
        private readonly Stopwatch stopwatch;

        public LoggingAsyncInterceptor()
        {
            this.stopwatch = Stopwatch.StartNew();
        }

        public void Intercept(IInvocation invocation) => this.InterceptAsync(invocation);

        private void InterceptAsync(IInvocation invocation)
        {
            this.invocation = invocation;
            if (HasMethodAttributes()) return;

            this.StartProcess();
            invocation.Proceed();

            if (!IsAsyncMethod())
                this.EndedProcess();
            else
            {
                ((Task)invocation.ReturnValue).ContinueWith(task =>
                {
                    this.EndedProcess();

                });
            }
        }

        private void FinishProcess()
        {
            var time = stopwatch.Elapsed;
            var methodName = $"{invocation.TargetType}.{invocation.Method.Name}";

            Debug.WriteLine(string.Format("Method: {0}, Time: {1:D2}h:{2:D2}m:{3:D2}s:{4:D3}ms",
                methodName,
                time.Hours,
                time.Minutes,
                time.Seconds,
                time.Milliseconds));
        }

        private bool IsAsyncMethod()
        {
            var method = this.invocation.Method;

            return (method.ReturnType == typeof(Task) ||
                   (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)));
        }

        private bool HasMethodAttributes()
        {
            return this.invocation.TargetType.GetMethod(this.invocation.Method.Name).GetCustomAttribute(typeof(NoLogAttribute), false) != null;
        }

        private void SetValueVariables(bool startProcess = true)
        {
            var methodName = $"{invocation.TargetType}.{invocation.Method.Name}";
            string argumentsType;
            string valueReturn;

            if (startProcess)
            {
                valueReturn = invocation.Arguments.Length == 0 ? "{}" : JsonConvert.SerializeObject(invocation.Arguments[0]);
                argumentsType = invocation.Arguments.Length == 0 ? "{}" : invocation.Arguments[0].GetType().ToString();
            }
            else
            {
                valueReturn = invocation.ReturnValue == null ? "{}" : JsonConvert.SerializeObject(invocation.ReturnValue);
                argumentsType = invocation.ReturnValue == null ? "{}" : invocation.ReturnValue.GetType().ToString();
            }

            Debug.WriteLine($"Method: {methodName}, TypeClass: {argumentsType}, Object: {valueReturn}");
        }
        private void StartProcess() => this.SetValueVariables();
        private void EndedProcess()
        {
            this.SetValueVariables(false);
            this.stopwatch.Stop();
            this.FinishProcess();
        }
    }
}