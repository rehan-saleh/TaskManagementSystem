using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.EmployeeInRoleBLL
{
    public interface IEmployeeInRoleBLL
    {
        IQueryable<EmployeeInRoleViewModel> GetAll();
    }
}
