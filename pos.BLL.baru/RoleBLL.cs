using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.BLL.DTO;
using pos.BLL.Interface;
using pos.DAL;
using pos.DAL.Interface;

namespace pos.BLL
{
    public class RoleBLL: IRoleBLL
    {
        private readonly IRole roleDAL;
        public RoleBLL()
        {
            roleDAL = new pos.DAL.DAL.Role();
        }
        public void AddUserToRole(string username, int roleId)
        {
            roleDAL.AddUserToRole(username, roleId);
        }
        public void AddRole(string roleName)
        {
            roleDAL.Insert(new pos.BO.Roles { RoleName = roleName });
        }
        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var roles = roleDAL.GetAll();
            List<RoleDTO> list = new List<RoleDTO>();
            foreach (var item in roles)
            {
                list.Add(new RoleDTO
                {
                    RoleID = item.RoleID,
                    RoleName = item.RoleName
                });
            }
            return list;
        }

    }
}
