using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain;
using posServices.Domain.Models;

namespace posServices.BLL.DTOs
{
    public class CreateReservasiDTO
    {
        public string NamaPelanggan { get; set; }
        public int IdMeja { get; set; }
        public DateTime TanggalReservasi { get; set; }
        public TimeOnly JamReservasi { get; set; }
    }

}


