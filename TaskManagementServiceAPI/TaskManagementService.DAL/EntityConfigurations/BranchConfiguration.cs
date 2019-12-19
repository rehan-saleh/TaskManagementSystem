using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class BranchConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchConfiguration()
        {
            ToTable("tblBranches");

            Property(b => b.BranchId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();

            Property(b => b.BranchName)
            .IsRequired()
            .HasMaxLength(100);

            // from Left to right
            HasRequired(c => c.Company)
            .WithMany(b => b.Branches)
            .HasForeignKey(f => f.CompanyId).WillCascadeOnDelete(false);
        }
    }
}
