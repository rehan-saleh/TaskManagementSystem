using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class EmployeeInRoleConfiguration : EntityTypeConfiguration<EmployeeInRole>
    {
        public EmployeeInRoleConfiguration()
        {
            ToTable("tblEmployeesInRoles");
            HasKey(o => new { o.UserId, o.EmployeeId });
        }
    }
}
