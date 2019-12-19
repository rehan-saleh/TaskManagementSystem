using System.Linq;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.DepartmentBLL
{
    public interface IDepartmentBLL
    {
        IQueryable<DepartmentViewModel> GetAll();
    }
}
