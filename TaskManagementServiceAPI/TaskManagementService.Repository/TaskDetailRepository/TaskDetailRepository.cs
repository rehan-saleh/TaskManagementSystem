using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.TaskDetailRepository
{
    public class TaskDetailRepository : BaseRepository<TaskManagementServiceContext, TaskDetail>, ITaskDetailRepository
    {
    }
}
