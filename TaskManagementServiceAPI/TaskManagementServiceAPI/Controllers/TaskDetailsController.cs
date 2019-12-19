using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.TaskDetailService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/taskdetails")]
    public class TaskDetailsController : ApiController
    {
        ITaskDetailService taskDetailService = null;
        public TaskDetailsController()
        {
            this.taskDetailService = new TaskDetailService();
        }
        // GET: api/TaskDetails
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    return Json(this.taskDetailService.GetTaskDetails());
        //}

        // GET: api/TaskDetails
        [HttpGet, Route("details/{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Json(this.taskDetailService.GetTaskDetailById(id));
        }

        // POST: api/TaskDetails
        [HttpPost]
        public void Post(TaskDetail taskDetail)
        {
            this.taskDetailService.AddUpdateTaskDetail(taskDetail);
        }

        // PUT: api/TaskDetails/5
        [HttpPut, Route("{id}")]
        public void Put(TaskDetail taskDetail)
        {
            this.taskDetailService.AddUpdateTaskDetail(taskDetail);
        }

        // DELETE: api/TaskDetails/5
        [HttpDelete, Route("delete/{taskDetailId}")]
        public void Delete(int taskDetailId)
        {
            this.taskDetailService.DeleteTaskDetail(taskDetailId);
        }
    }
}
