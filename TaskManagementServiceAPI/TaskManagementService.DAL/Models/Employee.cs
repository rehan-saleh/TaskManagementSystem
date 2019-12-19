using System.Collections.Generic;

namespace TaskManagementService.DAL.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeCnic { get; set; }
        public string EmployeeMobile1 { get; set; }
        public string EmployeeMobile2 { get; set; }
        public string EmployeeEmail1 { get; set; }
        public string EmployeeEmail2 { get; set; }
        public string EmployeeAddress1 { get; set; }
        public string EmployeeAddress2 { get; set; }
        //FK
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int DesignationId { get; set; }
        public Designation Designation { get; set; }

        public virtual ICollection<TaskDetail> TaskDetails { get; set; }
        public virtual ICollection<AllTask> AllTasks_CreatedByEmployee { get; set; }
        public virtual ICollection<AllTask> AllTasks_AssignedToEmployee { get; set; }
    }
}
