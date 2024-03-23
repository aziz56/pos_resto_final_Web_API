using System;
using System.Collections.Generic;
using System.Text;
using pos.BO;

namespace pos.BLL.DTO
{
    public class TransaksiPenjualanDTO
    {

        public int id_penjualan { get; set; }
        public string nama_menu { get; set; }
        public decimal harga_menu { get; set; }
        public int jumlah_pesanan { get; set; }
        public string nama_pelanggan { get; set; }
        public decimal amount { get; set; }
        public decimal kembalian { get; set; }
        public int no_meja { get; set; }
        public decimal total_penjualan { get; set; }    
    }
}
