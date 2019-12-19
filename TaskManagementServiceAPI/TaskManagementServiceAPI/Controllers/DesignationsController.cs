using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.DesignationService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/designations")]
    public class DesignationsController : ApiController
    {
        IDesignationService designationService;
        public DesignationsController()
        {
            this.designationService = new DesignationService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.designationService.GetDesignations());
        }

        [HttpPost]
        public void Post(Designation designation)
        {
            this.designationService.AddUpdateDesignation(designation);
        }

        [HttpPut, Route("{id}")]
        public void Put(Designation designation)
        {
            this.designationService.AddUpdateDesignation(designation);
        }

        [HttpDelete, Route("delete/{id}")]
        public void Delete(int id)
        {
            this.designationService.DeleteDesignation(id);
        }
    }
}
