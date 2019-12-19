using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementService.DAL.Models
{
    public class TaskDetail
    {
        public int TaskDetailId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDateTime { get; set; }
        public bool isReplyed { get; set; }

        //Foreign key navigation
        public int AllTaskId { get; set; }
        public virtual AllTask AllTask { get; set; }

        //Foreign key navigation
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
