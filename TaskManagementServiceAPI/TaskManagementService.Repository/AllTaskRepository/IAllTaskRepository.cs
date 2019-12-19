using System.Linq;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.AllTaskRepository
{
    public interface IAllTaskRepository : IBaseRepository<AllTask>
    {
        IQueryable<AllTask> GetAllTasks();
    }
}
