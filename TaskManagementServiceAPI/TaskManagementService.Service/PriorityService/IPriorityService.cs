using System.Linq;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.PriorityService
{
    public interface IPriorityService
    {
        IQueryable<Priority> GetPriorities();
    }
}
