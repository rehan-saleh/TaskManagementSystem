using System;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.DesignationRepository
{
    public class DesignationRepository : BaseRepository<TaskManagementServiceContext, Designation>, IDesignationRepository
    {
        public override void Add(Designation designation)
        {
            try
            {
                if (designation != null && designation.DesignationId > 0)
                {
                    var _designation = this.GetByID(designation.DesignationId);
                    _designation.DesignationName = designation.DesignationName;
                    _designation.CompanyId = designation.CompanyId;
                }
                else
                {
                    base.Add(designation);
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

