namespace RC.AOP
{
    public interface IEmployeeService
    {
        EmployeeResponse Save(EmployeeSaveRequest employee);
        EmployeeResponse Update(EmployeeUpdateRequest employee);
    }
}
