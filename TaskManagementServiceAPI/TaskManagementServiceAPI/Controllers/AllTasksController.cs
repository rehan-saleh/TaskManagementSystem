using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.AllTaskService;

namespace TaskManagementServiceAPI.Controllers
{
    [RoutePrefix("api/alltasks")]
    public class AllTasksController : ApiController
    {
        IAllTaskService allTaskService;
        public AllTasksController()
        {

            this.allTaskService = new AllTaskService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.allTaskService.GetAllTasks());
        }

        [HttpPost]
        public void Post(AllTask allTask)
        {
            this.allTaskService.AddUpdateAllTask(allTask);
        }

        [HttpPut, Route("{id}")]
        public void Put(AllTask allTask)
        {
            this.allTaskService.AddUpdateAllTask(allTask);
        }

        [HttpDelete, Route("delete/{id}")]
        public void Delete(int id)
        {
            this.allTaskService.DeleteAllTask(id);
        }
    }
}
