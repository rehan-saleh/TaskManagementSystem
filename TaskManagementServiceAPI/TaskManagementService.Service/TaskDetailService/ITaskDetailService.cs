using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.TaskDetailService
{
    public interface ITaskDetailService
    {
        IQueryable<TaskDetailViewModel> GetTaskDetailById(int id);
        void AddUpdateTaskDetail(TaskDetail taskDetail);
        void DeleteTaskDetail(int taskDetailId);
    }
}
