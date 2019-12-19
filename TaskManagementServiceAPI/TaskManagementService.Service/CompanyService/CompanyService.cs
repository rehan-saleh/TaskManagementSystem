using System;
using System.Linq;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.CompanyRepository;

namespace TaskManagementService.Service.CompanyService
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository companyRepository;

        public CompanyService()
        {
            this.companyRepository = new CompanyRepository();
        }

        public IQueryable<Company> GetCompanies()
        {
            return this.companyRepository.GetAll();
        }

        public void AddUpdateCompany(Company company)
        {
            try
            {
                if (company != null && company.CompanyId > 0)
                {
                    var _company = this.companyRepository.GetByID(company.CompanyId);
                    _company.CompanyName = company.CompanyName;
                    _company.CompanyAddress = company.CompanyAddress;
                    _company.CompanyRegistrationNumber = company.CompanyRegistrationNumber;
                    _company.CompanyTaxNumber = company.CompanyTaxNumber;
                }
                else
                {
                    this.companyRepository.Add(company);
                }
                this.companyRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCompany(int companyId)
        {
            try
            {
                var company = this.companyRepository.GetByID(companyId);
                this.companyRepository.Delete(company);
                this.companyRepository.Save();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
