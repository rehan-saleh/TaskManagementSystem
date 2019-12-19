using System.Web.Http;
using TaskManagementService.DAL.Models;
using TaskManagementService.Service.LevelService;

namespace TaskManagementServiceAPI.Controllers
{
    [Authorize, RoutePrefix("api/levels")]
    public class LevelsController : ApiController
    {
        ILevelService levelService = null;
        public LevelsController()
        {
            this.levelService = new LevelService();
        }
        // GET: api/Leveles
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(this.levelService.GetLevels());
        }


        // POST: api/Levels
        [HttpPost]
        public void Post(Level level)
        {
            this.levelService.AddUpdateLevel(level);
        }

        // PUT: api/Levels/5
        [HttpPut, Route("{id}")]
        public void Put(Level level)
        {
            this.levelService.AddUpdateLevel(level);
        }

        // DELETE: api/Levels/5
        [HttpDelete, Route("delete/{levelId}")]
        public void Delete(int levelId)
        {
            this.levelService.DeleteLevel(levelId);
        }
    }
}
