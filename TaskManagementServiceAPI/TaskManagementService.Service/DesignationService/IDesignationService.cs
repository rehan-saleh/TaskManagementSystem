using System.Linq;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;

namespace TaskManagementService.Service.DesignationService
{
    public interface IDesignationService
    {
        IQueryable<DesignationViewModel> GetDesignations();
        void AddUpdateDesignation(Designation designation);
        void DeleteDesignation(int designationId);
    }
}
