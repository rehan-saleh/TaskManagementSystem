using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;
using TaskManagementService.Repository.BranchRepository;

namespace TaskManagementService.BLL.BranchesBLL
{
    public class BranchBLL : IBranchBLL
    {
        private readonly IBranchRepository branchRepository = null;
        TaskManagementServiceContext db = new TaskManagementServiceContext();

        public BranchBLL()
        {
            branchRepository = new BranchRepository();
        }
        public IQueryable<BranchViewModel> GetAll()
        {
            var result = from c in db.Companies
                         join b in db.Branches on c.CompanyId equals b.CompanyId
                         select new BranchViewModel
                         {
                             BranchId = b.BranchId,
                             BranchName = b.BranchName,
                             BranchAddress = b.BranchAddress,
                             BranchEmail = b.BranchEmail,
                             CompanyId = b.CompanyId,
                             CompanyName = c.CompanyName
                         };
            return result;
        }
    }
}
