using System;
using System.Linq;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.LevelRepository;

namespace TaskManagementService.Service.LevelService
{
    public class LevelService : ILevelService
    {
        ILevelRepository levelRepository;

        public LevelService()
        {
            this.levelRepository = new LevelRepository();
        }

        public IQueryable<Level> GetLevels()
        {
            return this.levelRepository.GetAll();
        }

        public void AddUpdateLevel(Level level)
        {
            this.levelRepository.Add(level);
        }

        public void DeleteLevel(int levelId)
        {
            try
            {
                var level = this.levelRepository.GetByID(levelId);
                this.levelRepository.Delete(level);
                this.levelRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
