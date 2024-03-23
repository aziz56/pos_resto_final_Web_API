using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BLL.DTO
{
    public class TransactionDataDTO
    {
        public int id_penjualan { get; set; }
        public string nama_pelanggan { get; set; }
        public string nama_menu { get; set; }
        public decimal harga_menu { get; set; }
        public int no_meja { get; set; }
        public int jumlah_pesanan { get; set; }
        public decimal total_penjualan { get; set; }
        public decimal kembalian { get; set; }
        public decimal amount { get; set; }
        public int id_menu { get; set; }
        public int id_pelanggan { get; set; }
        public int id_meja { get; set; }
    }
}
