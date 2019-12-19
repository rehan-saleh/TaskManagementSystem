namespace TaskManagementService.DAL.OAuthContextMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagementService.DAL.Context.OAuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"OAuthContextMigrations";
        }

        protected override void Seed(TaskManagementService.DAL.Context.OAuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            // This Role as Application Administrator
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            // This Role Will See All Tasks List Within Department
            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            // This Role Will See All Tasks List of All Departments
            if (!context.Roles.Any(r => r.Name == "Superuser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Superuser" };

                manager.Create(role);
            }

            // This Role Will See All Tasks Only Assigned and Created Own Tasks
            if (!context.Roles.Any(r => r.Name == "EmployLogin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "EmployLogin" };

                manager.Create(role);
            }





            // This is Login for Appcation Admin ROLE
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@es.net"
                };
                manager.Create(user, "786786786");
                manager.AddToRole(user.Id, "AppAdmin");
            }
        }
    }
}
