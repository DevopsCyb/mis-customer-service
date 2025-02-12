using Microsoft.EntityFrameworkCore;
using Mis.Services.Customer.Api.Models;
using Mis.Services.Customer.Api.Models;
using Mis.Services.Customer.Api.Repository;

namespace Mis.Services.Customer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private MisServicesCustomerDatabaseContext _misProjectContext { get; set; }
        public ProjectRepository(MisServicesCustomerDatabaseContext misProjectContext)
        {
            _misProjectContext = misProjectContext;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _misProjectContext.Projects.ToListAsync();
        }
    }
}
