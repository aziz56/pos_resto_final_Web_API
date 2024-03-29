using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;

namespace posServices.BLL.DTOs
{
    public class ReservasiDTO
    {
        public TransaksiReservasi TransaksiReservasi { get; set; }
        public string NamaPelanggan { get; set; }
    }
}
}
