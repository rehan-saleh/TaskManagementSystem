using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchEmail { get; set; }

        //FK
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //Navigation
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
