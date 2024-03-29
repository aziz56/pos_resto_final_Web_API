using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posServices.BLL.DTOs
{
    public class GetTransaksiDTO
    {
        public string NamaPelanggan { get; set; }
        public DateTime TanggalPenjualan { get; set; }
        public TimeSpan WaktuPenjualan { get; set; }
        public decimal TotalPenjualan { get; set; }
        public decimal Amount { get; set; }
        public decimal Kembalian { get; set; }
        public string NamaMenu { get; set; }
        public decimal HargaMenu { get; set; }
        public int NoMeja { get; set; }
    }
}
