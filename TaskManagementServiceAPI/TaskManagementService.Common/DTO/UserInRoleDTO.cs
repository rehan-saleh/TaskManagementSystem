using System.Collections.Generic;

namespace TaskManagementService.Common.DTO
{
    public class UserInRoleDTO<TEmployee, TUser, TRole>
    {
        public TEmployee Employee { get; set; }
        public TUser User { get; set; }
        public IList<TRole> Roles { get; set; }
    }
}
