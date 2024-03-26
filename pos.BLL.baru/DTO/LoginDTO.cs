using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pos.BLL.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        //[JsonIgnore]
        public string Token { get; set; }
    }
}
