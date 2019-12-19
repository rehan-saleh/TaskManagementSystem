using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class AllTaskConfiguration : EntityTypeConfiguration<AllTask>
    {
        public AllTaskConfiguration()
        {
            ToTable("tblAllTasks");
            HasKey(T => T.AllTaskId);

            Property(T => T.AllTaskId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TaskSubject)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.TaskBody)
                .HasMaxLength(300);

            Property(t => t.TaskCode)
              .HasMaxLength(10)
              .IsRequired();

            Property(t => t.CreatedDate)
                .IsRequired();

            HasRequired(t => t.TaskType)
                .WithMany(t => t.AllTasks)
                .HasForeignKey(f => f.TaskTypeId).WillCascadeOnDelete(false);

            HasRequired(t => t.Level)
                .WithMany(t => t.AllTasks)
                .HasForeignKey(f => f.LevelId).WillCascadeOnDelete(false);

            HasRequired(t => t.Priority)
                .WithMany(t => t.AllTasks)
                .HasForeignKey(f => f.PriorityId).WillCascadeOnDelete(false);

            HasRequired(t => t.CreatedByEmployee)
                .WithMany(t => t.AllTasks_CreatedByEmployee)
                .HasForeignKey(f => f.CreatedByEmployeeId).WillCascadeOnDelete(false);

            HasRequired(t => t.AssignedToEmployee)
                .WithMany(t => t.AllTasks_AssignedToEmployee)
                .HasForeignKey(f => f.AssignedToEmployeeId).WillCascadeOnDelete(false);

            HasRequired(t => t.Department)
                .WithMany(t => t.AllTasks)
                .HasForeignKey(f => f.AssignedToDepartmentId).WillCascadeOnDelete(false);
        }
    }
}
