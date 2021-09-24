using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.AOP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customer)
        {
            this.customerService = customer;
        }

        [HttpPost]
        [Route("save")]
        public void Post()
        {
            this.customerService.Save(new CustomerSaveRequest { Name = "Name One" });
        }

        [HttpPut]
        [Route("update")]
        public void Put()
        {
            this.customerService.Update(new CustomerUpdateRequest { Id = 1, Name = "Name One" });
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IEnumerable<CustomerResponse>> Get()
        {
            return await this.customerService.GetAll();
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete()
        {
            this.customerService.Delete(1);
        }
    }
}