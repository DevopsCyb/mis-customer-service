using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Mis.Services.Customer.Api.Models;
using Mis.Services.Customer.Api.Models;
using System.Drawing.Text;

namespace Mis.Services.Customer.Api.Repository
{
    public class CustomerRepository : ICustomerRepository

    { 
          private MisServicesCustomerDatabaseContext _misCustomerContext { get; set; }
           
           public CustomerRepository(MisServicesCustomerDatabaseContext misCustomerContext)
        {
            _misCustomerContext = misCustomerContext;
        }
        public async Task<IEnumerable<Mis.Services.Customer.Api.Models.Customer>> GetAllAsync()
        {
            return await _misCustomerContext.Customers.ToListAsync();
        }
        public async Task<Mis.Services.Customer.Api.Models.Customer> GetCustomer(int id)
        {
            return await _misCustomerContext.Customers.FindAsync(id);
        }

        public async Task<Mis.Services.Customer.Api.Models.Customer> PostCustomer(int id, Mis.Services.Customer.Api.Models.Customer customer)
        {
           _misCustomerContext.Customers.Add(customer);
            _misCustomerContext.SaveChanges();
            return customer ;
        }

        public  void DeleteCustomer(Mis.Services.Customer.Api.Models.Customer cus)
        {
              _misCustomerContext.Customers.Remove(cus);
        }
    }
}
