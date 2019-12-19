using System;

namespace TaskManagementService.Common.ViewModels
{
    public class AllTaskViewModel
    {
        public int AllTaskId { get; set; }
        public string TaskCode { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedToCode { get; set; }
        public string TaskSubject { get; set; }
        public string TaskBody { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool isActive { get; set; }
        public bool isReplyed { get; set; }
        public bool isClosed { get; set; }
        public int TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int AssignedToEmployeeId { get; set; }
        public string AssignedToEmployeeName { get; set; }
        public string AssignedToEmployeeCode { get; set; }
        public string AssignedToEmployeeBranchName { get; set; }
        public string AssignedToEmployeeDepartmentName { get; set; }
        public string AssignedToEmployeeDesignationName { get; set; }
    }
}
