using System;
using System.Linq;
using TaskManagementService.BLL.DepartmentBLL;
using TaskManagementService.Common.ViewModels;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.DepartmentRepository;

namespace TaskManagementService.Service.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository departmentRepository;
        IDepartmentBLL departmentBLL;

        public DepartmentService()
        {
            this.departmentRepository = new DepartmentRepository();
            this.departmentBLL = new DepartmentBLL();
        }

        public IQueryable<DepartmentViewModel> GetDepartments()
        {
            return this.departmentBLL.GetAll();
        }

        public void AddUpdateDepartment(Department department)
        {
            this.departmentRepository.Add(department);
        }

        public void DeleteDepartment(int departmentId)
        {
            try
            {
                var department = this.departmentRepository.GetByID(departmentId);
                this.departmentRepository.Delete(department);
                this.departmentRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
