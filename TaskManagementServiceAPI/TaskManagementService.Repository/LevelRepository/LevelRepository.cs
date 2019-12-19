using System;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.LevelRepository
{
    public class LevelRepository : BaseRepository<TaskManagementServiceContext, Level>, ILevelRepository
    {
        public override void Add(Level level)
        {
            try
            {
                if (level != null && level.LevelId > 0)
                {
                    var _level = this.GetByID(level.LevelId);
                    _level.LevelName = level.LevelName;
                }
                else
                {
                    base.Add(level);
                }
                this.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
