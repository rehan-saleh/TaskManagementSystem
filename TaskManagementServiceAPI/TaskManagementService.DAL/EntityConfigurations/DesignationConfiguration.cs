using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class DesignationConfiguration : EntityTypeConfiguration<Designation>
    {
        public DesignationConfiguration()
        {
            ToTable("tblDesignations");

            Property(Ds => Ds.DesignationId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();

            Property(Ds => Ds.DesignationName)
            .HasMaxLength(100)
            .IsRequired();

            HasRequired(Ds => Ds.Company)
            .WithMany(ds => ds.Designations)
            .HasForeignKey(f => f.CompanyId).WillCascadeOnDelete(false);
        }
    }
}
