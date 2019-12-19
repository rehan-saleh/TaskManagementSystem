using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.DepartmentService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        IDepartmentService departmentService;
        public DepartmentsController()
        {
            this.departmentService = new DepartmentService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.departmentService.GetDepartments());
        }

        [HttpPost]
        public void Post(Department department)
        {
            this.departmentService.AddUpdateDepartment(department);
        }

        [HttpPut, Route("{id}")]
        public void Put(Department department)
        {
            this.departmentService.AddUpdateDepartment(department);
        }

        [HttpDelete, Route("delete/{id}")]
        public void Delete(int id)
        {
            this.departmentService.DeleteDepartment(id);
        }
    }
}
