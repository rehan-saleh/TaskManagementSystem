using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementService.DAL.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        // FK
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //Navigation
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
