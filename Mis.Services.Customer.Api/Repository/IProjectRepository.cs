using Mis.Services.Customer.Api.Models;

namespace Mis.Services.Customer.Api.Repository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
    }
}
