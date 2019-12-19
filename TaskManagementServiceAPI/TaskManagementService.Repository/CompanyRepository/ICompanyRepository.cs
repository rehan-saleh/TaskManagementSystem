using System.Linq;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.CompanyRepository
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
    }
}
