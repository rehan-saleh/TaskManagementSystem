using System.Linq;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.AllTaskRepository
{
    public class AllTaskRepository : BaseRepository<TaskManagementServiceContext, AllTask>, IAllTaskRepository
    {
        public IQueryable<AllTask> GetAllTasks()
        {
            var query = GetAll();
            return query;
        }

        public override void Add(AllTask entity)
        {
            var _task = Context.AllTasks.LastOrDefault();
            if (_task != null && !string.IsNullOrEmpty(_task.TaskCode))
            {
                entity.TaskCode = _task.TaskCode + "1";
            }
            else
            {
                entity.TaskCode = "T001";
            }
            base.Add(entity);
        }
    }
}
