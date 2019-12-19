using System;
using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class AllTask
    {
        public int AllTaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskSubject { get; set; }
        public string TaskBody { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool isActive { get; set; }
        public bool isReplyed { get; set; }
        public bool isClosed { get; set; }

        //Foreign key
        public int TaskTypeId { get; set; }
        public virtual TaskType TaskType { get; set; }

        //Foreign key
        public int? LevelId { get; set; }
        public virtual Level Level { get; set; }
        
        //Foreign key
        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }

        //Foriegn Key
        public int CreatedByEmployeeId { get; set; }
        public virtual Employee CreatedByEmployee { get; set; }

        //Foreign key
        public int? AssignedToEmployeeId { get; set; }
        public virtual Employee AssignedToEmployee { get; set; }

        //Foreign key
        public int? AssignedToDepartmentId { get; set; }
        public virtual Department Department { get; set; }

        //Navigation
        public virtual ICollection<TaskDetail> TaskDetails { get; set; }
    }
}
