using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.BranchService
{
    public interface IBranchService
    {
        IQueryable<BranchViewModel> GetBranches();
        void AddUpdateBranch(Branch branch);
        void DeleteBranch(int branchId);
    }
}
