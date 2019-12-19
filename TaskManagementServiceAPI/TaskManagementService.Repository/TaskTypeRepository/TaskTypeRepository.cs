using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.TaskTypeRepository
{
    public class TaskTypeRepository : BaseRepository<TaskManagementServiceContext, TaskType>, ITaskTypeRepository
    {
    }
}
