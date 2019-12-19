using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class PriorityConfiguration : EntityTypeConfiguration<Priority>
    {
        public PriorityConfiguration()
        {
            ToTable("tblPriorities");
            HasKey(T => T.PriorityId);

            Property(T => T.PriorityId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(T => T.PriorityName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
