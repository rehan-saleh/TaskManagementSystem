using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;
using TaskManagementService.Repository.DepartmentRepository;

namespace TaskManagementService.BLL.DepartmentBLL
{
    public class DepartmentBLL : IDepartmentBLL
    {
        private readonly IDepartmentRepository departmentRepository = null;
        TaskManagementServiceContext db = new TaskManagementServiceContext();

        public DepartmentBLL()
        {
            this.departmentRepository = new DepartmentRepository();
        }

        public IQueryable<DepartmentViewModel> GetAll()
        {
            var result = from c in db.Companies
                         join d in db.Departments on c.CompanyId equals d.CompanyId
                         select new DepartmentViewModel
                         {
                             DepartmentId = d.DepartmentId,
                             DepartmentCode = d.DepartmentCode,
                             DepartmentName = d.DepartmentName,
                             CompanyId = d.CompanyId,
                             CompanyName = c.CompanyName
                         };
            return result;
        }
    }
}
