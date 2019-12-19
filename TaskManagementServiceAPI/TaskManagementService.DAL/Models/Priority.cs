using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }

        //Nav
        public virtual ICollection<AllTask> AllTasks { get; set; }
    }
}
