using System.Linq;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.BLL.BranchesBLL
{
    public interface IBranchBLL
    {
        IQueryable<BranchViewModel> GetAll();
    }
}
