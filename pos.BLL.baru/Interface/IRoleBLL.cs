using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;

namespace pos.BLL.Interface
{
    public interface IRoleBLL
    {
        IEnumerable<RoleDTO> GetAllRoles();
        void AddRole(string roleName);
        void AddUserToRole(string username, int roleId);

    }
}
