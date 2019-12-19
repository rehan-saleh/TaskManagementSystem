using System.Linq;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.LevelService
{
    public interface ILevelService
    {
        IQueryable<Level> GetLevels();
        void AddUpdateLevel(Level Level);
        void DeleteLevel(int levelId);
    }
}
