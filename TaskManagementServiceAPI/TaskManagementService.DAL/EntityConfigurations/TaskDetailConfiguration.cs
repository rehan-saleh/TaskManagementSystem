using System.Data.Entity.ModelConfiguration;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.DAL.EntityConfigurations
{
    public class TaskDetailConfiguration : EntityTypeConfiguration<TaskDetail>
    {
        public TaskDetailConfiguration()
        {
            ToTable("tblTaskDetails");
            HasKey(k => k.TaskDetailId);

            Property(d => d.Comment)
                .HasMaxLength(300)
                .IsRequired();

            Property(d => d.CommentDateTime)
                .IsRequired();

            HasRequired(t => t.AllTask)
                .WithMany(d => d.TaskDetails)
                .HasForeignKey(f => f.AllTaskId).WillCascadeOnDelete(false);

            HasRequired(t => t.Employee)
                .WithMany(d => d.TaskDetails)
                .HasForeignKey(f => f.EmployeeId).WillCascadeOnDelete(false);
        }
    }
}