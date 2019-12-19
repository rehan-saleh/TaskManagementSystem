using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.AllTaskService
{
    public interface IAllTaskService
    {
        IQueryable<AllTaskViewModel> GetAllTasks();
        void AddUpdateAllTask(AllTask allTask);
        void DeleteAllTask(int allTaskId);
    }
}
