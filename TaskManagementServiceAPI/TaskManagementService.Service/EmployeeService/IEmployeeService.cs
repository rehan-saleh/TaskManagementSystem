using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.EmployeeService
{
    public interface IEmployeeService
    {
        IQueryable<EmployeeViewModel> GetEmployees();
        void AddUpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
