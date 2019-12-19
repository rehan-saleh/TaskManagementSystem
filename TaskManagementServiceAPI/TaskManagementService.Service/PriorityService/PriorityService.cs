using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.PriorityRepository;

namespace TaskManagementService.Service.PriorityService
{
    public class PriorityService : IPriorityService
    {
        IPriorityRepository priorityRepository;

        public PriorityService()
        {
            this.priorityRepository = new PriorityRepository();
        }

        public IQueryable<Priority> GetPriorities()
        {
            return this.priorityRepository.GetAll();
        }
    }
}
