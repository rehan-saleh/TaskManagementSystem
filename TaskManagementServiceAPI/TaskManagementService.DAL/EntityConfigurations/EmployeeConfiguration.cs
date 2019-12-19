using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("tblEmployees");
            HasKey(e => e.EmployeeId);

            Property(e => e.EmployeeId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();

            Property(e => e.EmployeeName)
            .HasMaxLength(100)
            .IsRequired();

            Property(e => e.EmployeeCode)
            .HasMaxLength(14)
            .IsRequired();

            Property(e => e.EmployeeCnic)
            .HasMaxLength(100)
            .IsRequired();

            Property(e => e.EmployeeEmail1)
            .HasMaxLength(100);

            Property(e => e.EmployeeEmail2)
            .HasMaxLength(100);

            Property(e => e.EmployeeMobile1)
            .HasMaxLength(100);

            Property(e => e.EmployeeMobile2)
            .HasMaxLength(100);

            Property(e => e.EmployeeAddress1)
            .HasMaxLength(1000);

            Property(e => e.EmployeeAddress2)
            .HasMaxLength(1000);

            //FK
            HasRequired(c => c.Branch)
            .WithMany(b => b.Employees)
            .HasForeignKey(f => f.BranchId);

            HasRequired(c => c.Department)
           .WithMany(b => b.Employees)
           .HasForeignKey(f => f.DepartmentId);

            HasRequired(c => c.Designation)
            .WithMany(b => b.Employees)
            .HasForeignKey(f => f.DesignationId);
        }
    }
}
