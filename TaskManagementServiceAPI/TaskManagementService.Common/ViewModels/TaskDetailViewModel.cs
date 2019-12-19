using System;

namespace TaskManagementService.Common.ViewModels
{
    public class TaskDetailViewModel
    {
        public int TaskDetailId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDateTime { get; set; }
        public bool isCommentReplyed { get; set; }
        public string CommentEmployeeName { get; set; }
        public string CommentEmployeeDepartment { get; set; }
        public string CommentEmployeeCode { get; set; }
        public int AllTaskId { get; set; }
    }
}
