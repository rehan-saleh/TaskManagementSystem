using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CompanyTaxNumber { get; set; }

        //Navigation 1 - *
        public virtual ICollection<Department> Departments { get; set; }
        // Navigation 1 - *
        public virtual ICollection<Branch> Branches { get; set; }
        // Navigation 1 - *
        public virtual ICollection<Designation> Designations { get; set; }
    }
}
