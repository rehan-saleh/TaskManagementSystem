using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class LevelConfiguration : EntityTypeConfiguration<Level>
    {
        public LevelConfiguration()
        {
            ToTable("tblLevels");

            Property(c => c.LevelId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();

            Property(c => c.LevelName)
             .IsRequired()
             .HasMaxLength(50);
        }
    }
}
