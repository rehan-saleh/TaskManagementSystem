using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.BranchService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/branches")]
    public class BranchesController : ApiController
    {
        IBranchService branchService = null;
        public BranchesController()
        {
            this.branchService = new BranchService();
        }
        // GET: api/Branches
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.branchService.GetBranches());
        }


        // POST: api/Branches
        [HttpPost]
        public void Post(Branch branch)
        {
            this.branchService.AddUpdateBranch(branch);
        }

        // PUT: api/Branches/5
        [HttpPut, Route("{id}")]
        public void Put(Branch branch)
        {
            this.branchService.AddUpdateBranch(branch);
        }

        // DELETE: api/Branches/5
        [HttpDelete, Route("delete/{branchId}")]
        public void Delete(int branchId)
        {
            this.branchService.DeleteBranch(branchId);
        }
    }
}
