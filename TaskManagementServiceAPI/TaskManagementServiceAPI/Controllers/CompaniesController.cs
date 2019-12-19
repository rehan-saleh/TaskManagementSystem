using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.CompanyService;

namespace TaskManagementServiceAPI.Controllers
{
    [RoutePrefix("api/companies"), /*Authorize*/]
    public class CompaniesController : ApiController
    {
        ICompanyService companyService;
        public CompaniesController()
        {
            this.companyService = new CompanyService();
        }
        // GET: api/Companies
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.companyService.GetCompanies());
        }


        // POST: api/Companies
        [HttpPost]
        public void Post(Company company)
        {
            this.companyService.AddUpdateCompany(company);
        }

        // PUT: api/Companies/5
        [HttpPut, Route("{id}")]
        public void Put(Company company)
        {
            this.companyService.AddUpdateCompany(company);
        }

        // DELETE: api/Companies/5
        [HttpDelete, Route("delete/{id}")]
        public void Delete(int id)
        {
            this.companyService.DeleteCompany(id);
        }
    }
}
