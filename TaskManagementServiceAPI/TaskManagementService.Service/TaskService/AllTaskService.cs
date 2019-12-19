using System.Collections.Generic;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.AllTaskRepository;

namespace TaskManagementService.Service.TaskService
{
    public class AllTaskService
    {
        private readonly IAllTaskRepository tasksRepository = null;

        public AllTaskService()
        {
            this.tasksRepository = new AllTaskRepository();
        }
        //GET
        public IEnumerable<AllTask> GetAllTasks()
        {
            var response = tasksRepository.GetAllTasks();
            return response;
        }

        public void AddUpdateTask(AllTask task)
        {
            if (task != null && task.TaskId > 0)
            {
                var _task = tasksRepository.GetByID(task.TaskId);
                _task.TaskName = task.TaskName;
                _task.TaskType = task.TaskType;
            }
            else
            {
                tasksRepository.Add(task);
            }
            tasksRepository.Save();
        }

        public void DeleteTask(int taskId)
        {
            var task = tasksRepository.GetByID(taskId);
            tasksRepository.Delete(task);
            tasksRepository.Save();
        }
    }
}
