using Mis.Services.Customer.Api.Models;

namespace Mis.Services.Customer.Api.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Mis.Services.Customer.Api.Models.Customer>> GetAllAsync();
        Task<Mis.Services.Customer.Api.Models.Customer> GetCustomer(int id);
        Task<Mis.Services.Customer.Api.Models.Customer> PostCustomer(int id, Mis.Services.Customer.Api.Models.Customer customer);
       void DeleteCustomer(Mis.Services.Customer.Api.Models.Customer cus);



    }
    
}
