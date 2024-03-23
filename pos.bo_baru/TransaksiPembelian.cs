using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class TransaksiPembelian
    {
        public int id_penjualan { get; set; }
        public DateTime tanggal_penjualan { get; set; }
        public int id_pelanggan { get; set; }
        public TimeSpan waktu_penjualan { get; set; }
        public decimal harga_menu { get; set; }
        public decimal total_penjualan { get; set; }
        public string status_penjualan { get; set; }
        public string metode_pembayaran { get; set; }
        public TimeSpan waktu_pembayaran { get; set; }
        public DateTime tanggal_pembayaran { get; set; }
        public decimal amount_pembayaran { get; set; }
        public decimal kembalian { get; set; }  



    }
}
