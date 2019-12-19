using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;
using TaskManagementService.Repository.EmployeeRepository;

namespace TaskManagementService.BLL.EmployeeBLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployeeRepository employeeRepository = null;
        TaskManagementServiceContext db = new TaskManagementServiceContext();

        public EmployeeBLL()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public IQueryable<EmployeeViewModel> GetAll()
        {
            var result = (from e in db.Employees
                          join b in db.Branches on e.BranchId equals b.BranchId
                          join d in db.Departments on e.DepartmentId equals d.DepartmentId
                          join c in db.Companies on b.CompanyId equals c.CompanyId
                          join dn in db.Designations on e.DesignationId equals dn.DesignationId
                          select new EmployeeViewModel
                          {
                              EmployeeId = e.EmployeeId,
                              EmployeeName = e.EmployeeName,
                              EmployeeCode = e.EmployeeCode,
                              EmployeeCnic = e.EmployeeCnic,
                              EmployeeEmail1 = e.EmployeeEmail1,
                              EmployeeEmail2 = e.EmployeeEmail2,
                              EmployeeMobile1 = e.EmployeeMobile1,
                              EmployeeMobile2 = e.EmployeeMobile2,
                              EmployeeAddress1 = e.EmployeeAddress1,
                              EmployeeAddress2 = e.EmployeeAddress2,
                              CompanyId = b.CompanyId,
                              CompanyName = c.CompanyName,
                              BranchId = e.BranchId,
                              BranchName = b.BranchName,
                              DepartmentId = e.DepartmentId,
                              DepartmentName = d.DepartmentName,
                              DesignationId = e.DesignationId,
                              DesignationName = dn.DesignationName
                          });
            return result;
        }
    }
}
