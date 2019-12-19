namespace TaskManagementService.DAL.TaskManagementServiceContextMigrations
{
    using System.Data.Entity.Migrations;
    using TaskManagementService.Common.SQL;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagementService.DAL.Context.TaskManagementServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"TaskManagementServiceContextMigrations";
        }

        protected override void Seed(TaskManagementService.DAL.Context.TaskManagementServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand(StoredProcedures.sp_GetAllTasks);
            context.Database.ExecuteSqlCommand(StoredProcedures.sp_GetAllEmployeesInRoles);
        }
    }
}
