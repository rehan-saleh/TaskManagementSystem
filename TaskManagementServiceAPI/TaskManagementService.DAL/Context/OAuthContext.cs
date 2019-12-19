using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagementService.DAL.Context
{
    public class OAuthContext : IdentityDbContext<IdentityUser>
    {
        public OAuthContext() : base("OAuthContext")
        {
        }
    }
}
