using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.CompanyRepository
{
    public class CompanyRepository : BaseRepository<TaskManagementServiceContext, Company>, ICompanyRepository
    {
    }
}
