using System.Linq;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.DesignationBLL
{
    public interface IDesignationBLL
    {
        IQueryable<DesignationViewModel> GetAll();
    }
}
