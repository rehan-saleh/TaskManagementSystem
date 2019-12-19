using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.TaskTypeService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/tasktypes")]
    public class TaskTypesController : ApiController
    {
        ITaskTypeService taskTypeService = null;
        public TaskTypesController()
        {
            this.taskTypeService = new TaskTypeService();
        }
        // GET: api/TaskTypes
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.taskTypeService.GetTaskTypes());
        }


        // POST: api/TaskTypes
        [HttpPost]
        public void Post(TaskType taskType)
        {
            this.taskTypeService.AddUpdateTaskType(taskType);
        }

        // PUT: api/TaskTypes/5
        [HttpPut, Route("{id}")]
        public void Put(TaskType taskType)
        {
            this.taskTypeService.AddUpdateTaskType(taskType);
        }

        // DELETE: api/TaskTypes/5
        [HttpDelete, Route("delete/{taskTypeId}")]
        public void Delete(int taskTypeId)
        {
            this.taskTypeService.DeleteTaskType(taskTypeId);
        }
    }
}
