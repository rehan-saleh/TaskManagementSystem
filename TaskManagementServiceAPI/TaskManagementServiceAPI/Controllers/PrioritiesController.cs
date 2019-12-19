using System.Web.Http;
using TaskManagementService.Service.PriorityService;

namespace TaskManagementServiceAPI.Controllers
{
    [RoutePrefix("api/priorities")]
    public class PrioritiesController : ApiController
    {
        IPriorityService priorityService;
        public PrioritiesController()
        {
            this.priorityService = new PriorityService();
        }
        // GET: api/Companies
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.priorityService.GetPriorities());
        }

    }
}
