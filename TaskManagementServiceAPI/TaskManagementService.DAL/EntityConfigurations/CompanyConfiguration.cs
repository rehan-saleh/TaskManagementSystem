using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("tblCompanies");

            Property(c => c.CompanyId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();

            Property(c => c.CompanyName)
             .IsRequired()
             .HasMaxLength(50);

            Property(c => c.CompanyAddress)
            .HasMaxLength(300);

            Property(c => c.CompanyRegistrationNumber)
            .HasMaxLength(300);

            Property(c => c.CompanyTaxNumber)
            .HasMaxLength(300);
        }
    }
}
