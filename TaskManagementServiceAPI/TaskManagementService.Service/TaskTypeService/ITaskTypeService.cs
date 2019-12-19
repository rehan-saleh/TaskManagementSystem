using System.Linq;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.TaskTypeService
{
    public interface ITaskTypeService
    {
        IQueryable<TaskType> GetTaskTypes();
        void AddUpdateTaskType(TaskType taskType);
        void DeleteTaskType(int taskTypeId);
    }
}
