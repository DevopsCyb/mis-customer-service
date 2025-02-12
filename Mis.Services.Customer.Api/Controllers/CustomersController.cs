using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mis.Services.Customer.Api.Models;
using Mis.Services.Customer.Api.Repository;

namespace Mis.Services.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MisServicesCustomerDatabaseContext _context;
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(MisServicesCustomerDatabaseContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mis.Services.Customer.Api.Models.Customer>>> GetAllAsync()
        {
          //if (_context.Customers == null)
          //{
          //    return NotFound();
          //}
            return Ok(await _customerRepository.GetAllAsync());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<Mis.Services.Customer.Api.Models.Customer> GetCustomer(int id)
        {
        
            var customer = await _customerRepository.GetCustomer(id);

          
            return customer; 
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
 

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Mis.Services.Customer.Api.Models.Customer> PostCustomer(Mis.Services.Customer.Api.Models.Customer customer)
        {

            return  await _customerRepository.PostCustomer(customer.CustomerId,  customer);
         
          

            
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Mis.Services.Customer.Api.Models.Customer cus)
        {
            if(_customerRepository.GetCustomer(cus.CustomerId) != null ){
                _customerRepository.DeleteCustomer(cus);
                return Ok(cus.CustomerId);
            }
            else
            {
               return NotFound(cus.CustomerId);
            }
          

           
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
