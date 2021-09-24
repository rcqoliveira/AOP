namespace RC.AOP
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeResponse Save(EmployeeSaveRequest employee) => CreateItemResponse();

        [NoLog]
        public EmployeeResponse Update(EmployeeUpdateRequest employee) => CreateItemResponse();

        private EmployeeResponse CreateItemResponse()
        {
            return new EmployeeResponse
            {
                Id = 2,
                Name = "Bill Gates",
            };
        }
    }
}