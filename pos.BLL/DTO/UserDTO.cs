using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BLL.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<RoleDTO> Roles { get; set; }

    }
}
