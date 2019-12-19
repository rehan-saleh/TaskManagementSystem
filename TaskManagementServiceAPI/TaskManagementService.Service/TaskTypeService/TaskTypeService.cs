using System;
using System.Linq;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskTypeRepository;

namespace TaskManagementService.Service.TaskTypeService
{
    public class TaskTypeService : ITaskTypeService
    {
        ITaskTypeRepository taskTypeRepository;

        public TaskTypeService()
        {
            this.taskTypeRepository = new TaskTypeRepository();
        }

        public IQueryable<TaskType> GetTaskTypes()
        {
            return this.taskTypeRepository.GetAll();
        }

        public void AddUpdateTaskType(TaskType taskType)
        {
            this.taskTypeRepository.Add(taskType);
        }

        public void DeleteTaskType(int taskTypeId)
        {
            try
            {
                var taskType = this.taskTypeRepository.GetByID(taskTypeId);
                this.taskTypeRepository.Delete(taskType);
                this.taskTypeRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
