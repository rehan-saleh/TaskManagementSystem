using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        //FK
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //Navigation
        public virtual ICollection<AllTask> AllTasks { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
