using Microsoft.AspNetCore.Mvc;

namespace RC.AOP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [Route("save")]
        public void Post()
        {
            this.employeeService.Save(new EmployeeSaveRequest { Name = "Name One" });
        }

        [HttpPost]
        [Route("update")]
        public void Put()
        {
            this.employeeService.Update(new EmployeeUpdateRequest { Id = 1, Name = "Name One" });
        }

    }
}