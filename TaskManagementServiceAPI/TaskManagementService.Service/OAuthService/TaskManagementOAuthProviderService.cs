using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagementService.Common.DTO;
using TaskManagementService.Repository.AuthRepository;

namespace TaskManagementService.Service.OAuthService
{
    public class TaskManagementOAuthProviderService : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            using (var authRepository = new OAuthRepository())
            {
                var response = new ResponseDTO<OAuthGrantResourceOwnerCredentialsContext>();
                IdentityUser user = await authRepository.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("Invalid", "Invalid User Credentials");
                }
                else
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("Username", user.UserName));
                    identity.AddClaim(new Claim("Email", user.Email));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    var userRoles = authRepository.GetRoles(user.Id);
                    foreach (string roleName in userRoles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                    }
                    var additionalData = new AuthenticationProperties(new Dictionary<string, string>()
                    {
                        { "role", Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)},
                        { "userId", user.Id }
                    });
                    var token = new AuthenticationTicket(identity, additionalData);
                    context.Validated(token);
                }
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
