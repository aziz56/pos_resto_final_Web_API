using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class User
    {
        public User()
        {
            this.TransaksiPenjualans = new List<TransaksiPenjualan>();
            this.Roles = new List<Roles>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<TransaksiPenjualan> TransaksiPenjualans { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
    }
}
