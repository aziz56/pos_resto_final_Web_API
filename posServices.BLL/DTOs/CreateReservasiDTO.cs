using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using posServices.Domain;
using posServices.Domain.Models;

namespace posServices.BLL.DTOs
{
    public class TransaksiReservasiDTO
    {
     

        public string NamaPelanggan { get; set; }
       
        public DateTime TanggalReservasi { get; set; }
        public TimeSpan JamReservasi { get; set; }
        public List<TransaksiDetailReservasiDTO> DetailReservasi { get; set; }
    }

    public class TransaksiDetailReservasiDTO
    {
        public int IdReservasi { get; set; }
        public int IdMenu { get; set; }
        public int IdMeja { get; set; }
    }


}


