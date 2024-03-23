using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class Roles
    {
        public Roles()
        {
            this.UsersRoles = new List<UsersRoles>();
        }

        public string RoleName { get; set; }
        public int RoleID { get; set; }

        public IEnumerable<UsersRoles> UsersRoles { get; set; }
    }

}
