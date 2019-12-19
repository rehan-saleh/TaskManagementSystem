using System;
using System.Linq;
using TaskManagementService.BLL.EmployeeBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.EmployeeRepository;

namespace TaskManagementService.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        IEmployeeBLL employeeBLL;

        public EmployeeService()
        {
            this.employeeRepository = new EmployeeRepository();
            this.employeeBLL = new EmployeeBLL();
        }

        public IQueryable<EmployeeViewModel> GetEmployees()
        {
            return this.employeeBLL.GetAll();
        }

        public void AddUpdateEmployee(Employee employee)
        {
            this.employeeRepository.Add(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            try
            {
                var employee = this.employeeRepository.GetByID(employeeId);
                this.employeeRepository.Delete(employee);
                this.employeeRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
