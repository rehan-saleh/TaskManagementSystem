using System;
using System.Linq;
using TaskManagementService.BLL.TaskDetailBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskDetailRepository;

namespace TaskManagementService.Service.TaskDetailService
{
    public class TaskDetailService : ITaskDetailService
    {
        ITaskDetailRepository taskDetailRepository;
        ITaskDetailBLL taskDetailBLL;

        public TaskDetailService()
        {
            this.taskDetailRepository = new TaskDetailRepository();
            this.taskDetailBLL = new TaskDetailBLL();
        }

        public IQueryable<TaskDetailViewModel> GetTaskDetailById(int id)
        {
            return this.taskDetailBLL.GetTaskDetailById(id);
        }

        public void AddUpdateTaskDetail(TaskDetail taskDetail)
        {
            this.taskDetailRepository.Add(taskDetail);
        }

        public void DeleteTaskDetail(int taskDetailId)
        {
            try
            {
                var taskDetail = this.taskDetailRepository.GetByID(taskDetailId);
                this.taskDetailRepository.Delete(taskDetail);
                this.taskDetailRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
