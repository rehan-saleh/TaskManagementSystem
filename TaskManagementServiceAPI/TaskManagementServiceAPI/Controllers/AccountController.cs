using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TaskManagementService.Common.DTO;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.AuthRepository;
using TaskManagementService.Service.EmployeeService;
using TaskManagementService.Service.EmployeeInRoleService;

namespace TaskManagementServiceAPI.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController, IDisposable
    {
        private readonly OAuthRepository authRepo;
        private readonly IEmployeeInRoleService employeeInRoleService;

        public AccountController()
        {
            this.authRepo = new OAuthRepository();
            this.employeeInRoleService = new EmployeeInRoleService();
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateRole(Role viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await authRepo.CreateRole(viewModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost, Route("role")]
        public async Task<IHttpActionResult> Register(UserInRoleDTO<Employee, User, Role> userInRole)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IdentityResponse result = await authRepo.CreateUser(userInRole);

                if (result.Errors != null)
                {
                    return Json(result.Errors);
                }

                var employeeInRole = new EmployeeInRole
                {
                    EmployeeId = userInRole.Employee.EmployeeId,
                    UserId = result.UserId
                };

                this.employeeInRoleService.AddUpdateEmployeeInRole(employeeInRole);

                return Json(HttpStatusCode.OK);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                authRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        [Route("roles")]
        public IHttpActionResult GetAllRoles()
        {
            var result = this.authRepo.GetAllRoles();
            return Json(result);
        }
    }
}
