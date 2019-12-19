using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementService.Common.DTO;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Repository.AuthRepository
{
    public class OAuthRepository : IDisposable
    {
        private OAuthContext authContext;
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public OAuthRepository()
        {
            this.authContext = new OAuthContext();
            this.userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(authContext));
            this.roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(authContext));
        }

        public async Task<IdentityResult> CreateRole(Role roleViewModel)
        {
            try
            {
                IdentityRole role = new IdentityRole
                {
                    Name = roleViewModel.Name
                };

                var result = await this.roleManager.CreateAsync(role);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IdentityResponse> CreateUser(UserInRoleDTO<Employee, User, Role> userInRole)
        {
            try
            {
                var identityResponse = new IdentityResponse();

                IdentityUser user = new IdentityUser
                {
                    UserName = userInRole.User.UserName,
                   // Email = userInRole.User.Email
                };

                var result = await this.userManager.CreateAsync(user, userInRole.User.Password);
                if (result.Succeeded)
                {
                    foreach (var role in userInRole.Roles)
                    {
                        this.userManager.AddToRole(user.Id, role.Name);
                    }
                    identityResponse.UserId = user.Id;
                    identityResponse.Succeeded = result.Succeeded;
                }
                else
                {
                    identityResponse.Errors = result.Errors;
                }
                return identityResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            try
            {
                var result = await this.userManager.FindAsync(username, password);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IdentityRole> GetAllRoles()
        {
            try
            {
                var roleStore = new RoleStore<IdentityRole>(authContext);
                var roleMngr = new RoleManager<IdentityRole>(roleStore);
                var roles = roleMngr.Roles.ToList();
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<string> GetRoles(string userId)
        {
            try
            {
                var result = this.userManager.GetRoles(userId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            authContext.Dispose();
            userManager.Dispose();
            roleManager.Dispose();
        }
    }
}
