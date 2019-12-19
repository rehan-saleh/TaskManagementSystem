using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Context;

namespace TaskManagementService.BLL.AllTaskBLL
{
    public class AllTaskBLL : IAllTaskBLL
    {
        TaskManagementServiceContext db = new TaskManagementServiceContext();

        public IQueryable<AllTaskViewModel> GetAll()
        {
            var result = db.Database.SqlQuery<AllTaskViewModel>("sp_GetAllTasks").AsQueryable();
            return result;
        }
    }
}

