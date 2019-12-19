using System.Data.Entity;
using TaskManagementService.DAL.EntityConfigurations;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.Context
{
    public class TaskManagementServiceContext : DbContext
    {
        public TaskManagementServiceContext() : base("TaskManagementServiceContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<AllTask> AllTasks { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<EmployeeInRole> EmployeesInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new BranchConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new DesignationConfiguration());
            modelBuilder.Configurations.Add(new TaskTypeConfiguration());
            modelBuilder.Configurations.Add(new LevelConfiguration());
            modelBuilder.Configurations.Add(new AllTaskConfiguration());
            modelBuilder.Configurations.Add(new TaskDetailConfiguration());
            modelBuilder.Configurations.Add(new PriorityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeInRoleConfiguration());
        }
    }
}
