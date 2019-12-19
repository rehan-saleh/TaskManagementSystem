using System;
using System.Linq;
using TaskManagementService.BLL.EmployeeInRoleBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.EmployeeInRoleRepository;

namespace TaskManagementService.Service.EmployeeInRoleService
{
    public class EmployeeInRoleService : IEmployeeInRoleService
    {
        IEmployeeInRoleRepository employeeInRoleRepository;
        IEmployeeInRoleBLL employeeInRoleBLL;

        public EmployeeInRoleService()
        {
            this.employeeInRoleRepository = new EmployeeInRoleRepository();
            this.employeeInRoleBLL = new EmployeeInRoleBLL();
        }

        public IQueryable<EmployeeInRoleViewModel> GetEmployeesInRoles()
        {
            return this.employeeInRoleBLL.GetAll();
        }

        public void AddUpdateEmployeeInRole(EmployeeInRole employeeInRole)
        {
            this.employeeInRoleRepository.Add(employeeInRole);
        }

        public void DeleteEmployeeInRole(int employeeId)
        {
            try
            {
                var employeeInRole = this.employeeInRoleRepository.GetByID(employeeId);
                this.employeeInRoleRepository.Delete(employeeInRole);
                this.employeeInRoleRepository.Save();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
