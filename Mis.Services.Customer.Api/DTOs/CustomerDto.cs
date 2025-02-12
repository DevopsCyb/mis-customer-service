using Mis.Services.Customer.Api.Models;
namespace Mis.Services.Customer.Api.DTOs
{
    public class CustomerDto
    {
    
        public int id { get; set; }
        public string contact_person_email { get; set; }
        public string contact_person_name { get; set;}
        public string mobile { get; set;}
        public string name { get; set;}
        
    }
}
