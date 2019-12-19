using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.EmployeeService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        IEmployeeService employeeService = null;
        public EmployeesController()
        {
            this.employeeService = new EmployeeService();
        }
        // GET: api/Employees
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.employeeService.GetEmployees());
        }


        // POST: api/Employees
        [HttpPost]
        public void Post(Employee employee)
        {
            this.employeeService.AddUpdateEmployee(employee);
        }

        // PUT: api/Employees/5
        [HttpPut, Route("{id}")]
        public void Put(Employee employee)
        {
            this.employeeService.AddUpdateEmployee(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete, Route("delete/{employeeId}")]
        public void Delete(int employeeId)
        {
            this.employeeService.DeleteEmployee(employeeId);
        }
    }
}
