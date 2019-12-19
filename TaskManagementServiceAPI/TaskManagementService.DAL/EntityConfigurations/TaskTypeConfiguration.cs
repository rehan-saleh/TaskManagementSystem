using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class TaskTypeConfiguration : EntityTypeConfiguration<TaskType>
    {
        public TaskTypeConfiguration()
        {

            ToTable("tblTaskTypes");
            HasKey(k => k.TaskTypeId);

            Property(t => t.TaskTypeId)
                      .IsRequired();

            Property(t => t.TaskTypeName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
