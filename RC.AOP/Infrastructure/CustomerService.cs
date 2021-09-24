using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.AOP.Properties
{

    public class CustomerService : ICustomerService
    {
        public CustomerResponse Save(CustomerSaveRequest customer) => CreateItemResponse();
        public CustomerResponse Update(CustomerUpdateRequest customer) => CreateItemResponse();
        
        public void Delete(int customerId)
        {

        }

        public async Task<IEnumerable<CustomerResponse>> GetAll()
        {
            return await Task.FromResult(CreateListOfResponse());
        }

        private CustomerResponse CreateItemResponse()
        {
            return new CustomerResponse
            {
                Id = 2,
                Name = "Bill Gates",
                CreatedDate = DateTime.Now,
                RulesResponses = new List<RulesResponse>
                {
                    new RulesResponse { Id = 1, Name = "Rule 1" },
                    new RulesResponse { Id = 2, Name = "Rule 2" },
                    new RulesResponse { Id = 3, Name = "Rule 3" },
                    new RulesResponse { Id = 4, Name = "Rule 4" },
                    new RulesResponse { Id = 5, Name = "Rule 5" },
                }
            };
        }

        private IEnumerable<CustomerResponse> CreateListOfResponse()
        {
            IEnumerable<CustomerResponse> itemsCustomerResponse = new List<CustomerResponse> {
                new CustomerResponse
                {
                    Id = 2,
                    Name = "Bill Gates",
                    CreatedDate = DateTime.Now,
                    RulesResponses = new List<RulesResponse>
                    {
                        new RulesResponse { Id = 1, Name = "Rule 1" },
                        new RulesResponse { Id = 2, Name = "Rule 2" },
                        new RulesResponse { Id = 3, Name = "Rule 3" },
                        new RulesResponse { Id = 4, Name = "Rule 4" },
                        new RulesResponse { Id = 5, Name = "Rule 5" },
                    }
                },
                new CustomerResponse
                {
                    Id = 2,
                    Name = "Steve Jobs",
                    CreatedDate = DateTime.Now,
                    RulesResponses = new List<RulesResponse>
                    {
                        new RulesResponse { Id = 1, Name = "Rule 1" },
                        new RulesResponse { Id = 2, Name = "Rule 2" }
                    }
                },
            };

            return itemsCustomerResponse;
        }
    }
}
