using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementService.DAL.Models
{
    public class TaskType
    {
        public int TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }
        //Navigation
        public virtual ICollection<AllTask> AllTasks { get; set; }
    }
}
