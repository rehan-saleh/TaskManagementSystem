using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.DepartmentService
{
    public interface IDepartmentService
    {
        IQueryable<DepartmentViewModel> GetDepartments();
        void AddUpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
    }
}
