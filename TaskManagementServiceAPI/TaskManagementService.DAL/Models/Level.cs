using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class Level
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<AllTask> AllTasks { get; set; }
    }
}
