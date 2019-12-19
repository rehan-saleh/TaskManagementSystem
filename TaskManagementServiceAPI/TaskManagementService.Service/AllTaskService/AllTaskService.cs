using System;
using System.Linq;
using TaskManagementService.BLL.AllTaskBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.AllTaskRepository;

namespace TaskManagementService.Service.AllTaskService
{
    public class AllTaskService : IAllTaskService
    {
        IAllTaskRepository allTaskRepository;
        IAllTaskBLL allTaskBLL;

        public AllTaskService()
        {
            this.allTaskRepository = new AllTaskRepository();
            this.allTaskBLL = new AllTaskBLL();
        }

        public IQueryable<AllTaskViewModel> GetAllTasks()
        {
            return this.allTaskBLL.GetAll();
        }

        public void AddUpdateAllTask(AllTask allTask)
        {
            try
            {
                this.allTaskRepository.Add(allTask);
                this.allTaskRepository.Save();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void DeleteAllTask(int allTaskId)
        {
            try
            {
                var allTask = this.allTaskRepository.GetByID(allTaskId);
                this.allTaskRepository.Delete(allTask);
                this.allTaskRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
