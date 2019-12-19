using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;

namespace TaskManagementService.BLL.TaskDetailBLL
{
    public class TaskDetailBLL : ITaskDetailBLL
    {
        TaskManagementServiceContext db = new TaskManagementServiceContext();
        public IQueryable<TaskDetailViewModel> GetTaskDetailById(int id)
        {
            var result = (from t in db.TaskDetails
                          join e in db.Employees
                          on t.EmployeeId equals e.EmployeeId
                          join d in db.Departments
                          on e.DepartmentId equals d.DepartmentId
                          select new TaskDetailViewModel
                          {
                              TaskDetailId = t.TaskDetailId,
                              CommentDateTime = t.CommentDateTime,
                              CommentEmployeeName = e.EmployeeName,
                              isCommentReplyed = t.isReplyed,
                              CommentEmployeeCode = e.EmployeeCode,
                              CommentEmployeeDepartment = d.DepartmentName,
                              Comment = t.Comment,
                              AllTaskId = t.AllTaskId
                          }).Where(td => td.AllTaskId == id).AsQueryable();
            return result;
        }
    }
}
