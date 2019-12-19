using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("tblDepartments");

            Property(D => D.DepartmentId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();


            Property(D => D.DepartmentName)
            .HasMaxLength(300)
            .IsRequired();


            HasRequired(c => c.Company)
            .WithMany(d => d.Departments)
            .HasForeignKey(f => f.CompanyId).WillCascadeOnDelete(false);
        }
    }
}
