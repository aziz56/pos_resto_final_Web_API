using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class UsersRoles
    {
        public string Username { get; set; }
        public int RoleID { get; set; }

        public User User { get; set; }
        public Roles Role { get; set; }
    }
}
