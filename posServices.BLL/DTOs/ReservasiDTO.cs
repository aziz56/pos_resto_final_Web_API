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
        public List<(TransaksiReservasi transaksiReservasi, string namaPelanggan)> ParameterReservasi { get; set; }
}
}
