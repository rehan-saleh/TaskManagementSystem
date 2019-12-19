using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.Common.SQL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;
using TaskManagementService.Repository.EmployeeInRoleRepository;

namespace TaskManagementService.BLL.EmployeeInRoleBLL
{
    public class EmployeeInRoleBLL : IEmployeeInRoleBLL
    {
        private readonly IEmployeeInRoleRepository employeeInRoleRepository = null;
        TaskManagementServiceContext db = new TaskManagementServiceContext();

        public EmployeeInRoleBLL()
        {
            this.employeeInRoleRepository = new EmployeeInRoleRepository();
        }

        public IQueryable<EmployeeInRoleViewModel> GetAll()
        {
            var result = db.Database.SqlQuery<EmployeeInRoleViewModel>(nameof(StoredProcedures.sp_GetAllEmployeesInRoles)).AsQueryable();
            return result;
        }
    }
}
