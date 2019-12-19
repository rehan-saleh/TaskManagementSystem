using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.EmployeeInRoleService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/employeesinroles")]
    public class EmployeesInRolesController : ApiController
    {
        IEmployeeInRoleService employeeInRoleService = null;
        public EmployeesInRolesController()
        {
            this.employeeInRoleService = new EmployeeInRoleService();
        }
        // GET: api/EmployeesInRoles
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.employeeInRoleService.GetEmployeesInRoles());
        }


        // POST: api/EmployeesInRoles
        [HttpPost]
        public void Post(EmployeeInRole employeeInRole)
        {
            this.employeeInRoleService.AddUpdateEmployeeInRole(employeeInRole);
        }

        // PUT: api/EmployeesInRoles/5
        [HttpPut, Route("{id}")]
        public void Put(EmployeeInRole employeeInRole)
        {
            this.employeeInRoleService.AddUpdateEmployeeInRole(employeeInRole);
        }

        // DELETE: api/EmployeesInRoles/5
        [HttpDelete, Route("delete/{employeeId}")]
        public void Delete(int employeeId)
        {
            this.employeeInRoleService.DeleteEmployeeInRole(employeeId);
        }
    }
}
