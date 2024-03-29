using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posServices.BLL.DTOs
{
    public class InvoiceDTO
    {
        public int IdPenjualan { get; set; }
        public string NamaPelanggan { get; set; }
        public DateTime TanggalPenjualan { get; set; }
        public decimal TotalPenjualan { get; set; }
        public decimal Kembalian { get; set; }
        public List<InvoiceItemDTO> Items { get; set; }
    }

    public class InvoiceItemDTO
    {
        public int IdMenu { get; set; }
        public string NamaMenu { get; set; }
        public int JumlahPesanan { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal TotalHarga { get; set; }
    }

}
