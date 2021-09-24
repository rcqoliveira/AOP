using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.AOP
{
    public interface ICustomerService
    {
        CustomerResponse Save(CustomerSaveRequest customer);
        CustomerResponse Update(CustomerUpdateRequest customer);
        void Delete(int customerId);
        Task<IEnumerable<CustomerResponse>> GetAll();
    }
}