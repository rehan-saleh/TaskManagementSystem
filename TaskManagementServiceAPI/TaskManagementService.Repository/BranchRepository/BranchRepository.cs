using System;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.BranchRepository
{
    public class BranchRepository : BaseRepository<TaskManagementServiceContext, Branch>, IBranchRepository
    {
        public override void Add(Branch branch)
        {
            try
            {
                if (branch != null && branch.BranchId > 0)
                {
                    var _branch = this.GetByID(branch.BranchId);
                    _branch.BranchName = branch.BranchName;
                    _branch.BranchAddress = branch.BranchAddress;
                    _branch.BranchEmail = branch.BranchEmail;
                    _branch.CompanyId = branch.CompanyId;
                }
                else
                {
                    base.Add(branch);
                }
                this.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
