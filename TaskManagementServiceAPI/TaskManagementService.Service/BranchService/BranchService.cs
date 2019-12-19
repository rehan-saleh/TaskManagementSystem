using System;
using System.Linq;
using TaskManagementService.BLL.BranchesBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.BranchRepository;

namespace TaskManagementService.Service.BranchService
{
    public class BranchService : IBranchService
    {
        IBranchRepository branchRepository;
        IBranchBLL branchBLL;

        public BranchService()
        {
            this.branchRepository = new BranchRepository();
            this.branchBLL = new BranchBLL();
        }

        public IQueryable<BranchViewModel> GetBranches()
        {
            var branches = this.branchBLL.GetAll();
            return branches;
        }

        public void AddUpdateBranch(Branch branch)
        {
            this.branchRepository.Add(branch);
        }

        public void DeleteBranch(int branchId)
        {
            try
            {
                var branch = this.branchRepository.GetByID(branchId);
                this.branchRepository.Delete(branch);
                this.branchRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
