using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;
using TaskManagementService.Repository.DesignationRepository;

namespace TaskManagementService.BLL.DesignationBLL
{
    public class DesignationBLL : IDesignationBLL
    {
        private readonly IDesignationRepository designationRepository = null;
        TaskManagementServiceContext db = new TaskManagementServiceContext();

        public DesignationBLL()
        {
            this.designationRepository = new DesignationRepository();
        }

        public IQueryable<DesignationViewModel> GetAll()
        {
            var result = (from d in db.Designations
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          select new DesignationViewModel
                          {
                              DesignationId = d.DesignationId,
                              DesignationName = d.DesignationName,
                              CompanyId = d.CompanyId,
                              CompanyName = c.CompanyName,
                          });
            return result;
        }
    }
}
