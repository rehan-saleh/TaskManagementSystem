using System;
using TaskManagementService.DAL.Context;
using TaskManagementService.DAL.Models;
using TaskManagementService.Repository.TaskManagementServiceBaseRepository;

namespace TaskManagementService.Repository.DepartmentRepository
{
    public class DepartmentRepository : BaseRepository<TaskManagementServiceContext, Department>, IDepartmentRepository
    {
        public override void Add(Department department)
        {
            try
            {
                if (department != null && department.DepartmentId > 0)
                {
                    var _department = this.GetByID(department.DepartmentId);
                    _department.DepartmentName = department.DepartmentName;
                    _department.DepartmentCode = department.DepartmentCode;
                    _department.CompanyId = department.CompanyId;
                }
                else
                {
                    base.Add(department);
                }
                this.Save();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
