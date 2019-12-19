using System.Linq;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.TaskDetailBLL
{
    public interface ITaskDetailBLL
    {
        IQueryable<TaskDetailViewModel> GetTaskDetailById(int id);
    }
}
