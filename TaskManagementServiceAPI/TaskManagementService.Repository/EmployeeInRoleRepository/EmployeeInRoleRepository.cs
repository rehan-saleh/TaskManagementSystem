using System;
using System.Linq;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.EmployeeInRoleRepository
{
    public class EmployeeInRoleRepository : BaseRepository<TaskManagementServiceContext, EmployeeInRole>, IEmployeeInRoleRepository
    {
        public override void Add(EmployeeInRole employeeInRole)
        {
            try
            {
                if (employeeInRole != null)
                {
                    var _employeeInRole = Context.EmployeesInRoles.FirstOrDefault(e => e.EmployeeId == employeeInRole.EmployeeId);
                    if (_employeeInRole != null)
                    {
                        _employeeInRole.EmployeeId = employeeInRole.EmployeeId;
                        _employeeInRole.UserId = employeeInRole.UserId;
                    }
                    else
                    {
                        base.Add(employeeInRole);
                    }
                }
                this.Save();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
