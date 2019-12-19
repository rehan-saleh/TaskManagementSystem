using System.Linq;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.EmployeeBLL
{
    public interface IEmployeeBLL
    {
        IQueryable<EmployeeViewModel> GetAll();
    }
}
