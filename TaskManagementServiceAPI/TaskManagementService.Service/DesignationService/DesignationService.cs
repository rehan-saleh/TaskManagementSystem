using System;
using System.Linq;
using TaskManagementService.BLL.DesignationBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.DesignationRepository;

namespace TaskManagementService.Service.DesignationService
{
    public class DesignationService : IDesignationService
    {
        IDesignationRepository designationRepository;
        IDesignationBLL designationBLL;

        public DesignationService()
        {
            this.designationRepository = new DesignationRepository();
            this.designationBLL = new DesignationBLL();
        }

        public IQueryable<DesignationViewModel> GetDesignations()
        {
            return this.designationBLL.GetAll();
        }

        public void AddUpdateDesignation(Designation designation)
        {
            this.designationRepository.Add(designation);
        }

        public void DeleteDesignation(int designationId)
        {
            try
            {
                var designation = this.designationRepository.GetByID(designationId);
                this.designationRepository.Delete(designation);
                this.designationRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
