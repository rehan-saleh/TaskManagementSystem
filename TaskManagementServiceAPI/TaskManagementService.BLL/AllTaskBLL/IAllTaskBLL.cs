using System.Linq;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.AllTaskBLL
{
    public interface IAllTaskBLL
    {
        IQueryable<AllTaskViewModel> GetAll();
    }
}
