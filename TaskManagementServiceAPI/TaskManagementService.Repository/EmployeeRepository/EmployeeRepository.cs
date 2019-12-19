using System;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.EmployeeRepository
{
    public class EmployeeRepository : BaseRepository<TaskManagementServiceContext, Employee>, IEmployeeRepository
    {
        public override void Add(Employee employee)
        {
            try
            {
                if (employee != null && employee.EmployeeId > 0)
                {
                    var _employee = this.GetByID(employee.EmployeeId);
                    _employee.EmployeeName = employee.EmployeeName;
                    _employee.EmployeeCnic = employee.EmployeeCnic;
                    _employee.EmployeeMobile1 = employee.EmployeeMobile1;
                    _employee.EmployeeMobile2 = employee.EmployeeMobile2;
                    _employee.EmployeeEmail1 = employee.EmployeeEmail1;
                    _employee.EmployeeEmail2 = employee.EmployeeEmail2;
                    _employee.EmployeeAddress1 = employee.EmployeeAddress1;
                    _employee.EmployeeAddress2 = employee.EmployeeAddress2;
                    _employee.EmployeeCode = employee.EmployeeCode;
                    _employee.BranchId = employee.BranchId;
                    _employee.DepartmentId = employee.DepartmentId;
                    _employee.DesignationId = employee.DesignationId;
                }
                else
                {
                    base.Add(employee);
                }
                this.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}