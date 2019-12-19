using System.Linq;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.CompanyService
{
    public interface ICompanyService
    {
        IQueryable<Company> GetCompanies();
        void AddUpdateCompany(Company company);
        void DeleteCompany(int companyId);
    }
}
