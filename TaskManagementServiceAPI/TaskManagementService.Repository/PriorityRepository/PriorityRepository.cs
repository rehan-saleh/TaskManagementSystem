using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.PriorityRepository
{
    public class PriorityRepository : BaseRepository<TaskManagementServiceContext, Priority>, IPriorityRepository
    {
    }
}
