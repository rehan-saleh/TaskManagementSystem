using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.EmployeeInRoleService
{
    public interface IEmployeeInRoleService
    {
        IQueryable<EmployeeInRoleViewModel> GetEmployeesInRoles();
        void AddUpdateEmployeeInRole(EmployeeInRole employeeInRole);
        void DeleteEmployeeInRole(int employeeId);
    }
}
