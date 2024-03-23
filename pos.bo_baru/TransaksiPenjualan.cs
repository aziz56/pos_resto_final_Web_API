using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
 
        public class TransaksiPenjualan
        {
            public int id_penjualan { get; set; }
            public DateTime? tanggal_penjualan { get; set; }
            public TimeSpan? waktu_penjualan { get; set; }
            public int? id_pelanggaan { get; set; }
            public int? id_meja { get; set; }
            public string Username { get; set; }
            public int? jumlah_pesanan { get; set; }
            public decimal? total_penjualan { get; set; }
            public int? id_menu { get; set; }
            public string keterangan { get; set; }
            public TimeSpan? waktu_pembayaran { get; set; }
            public DateTime? tanggal_pembayaran { get; set; }
            public decimal? kembalian { get; set; }
            public decimal? amount { get; set; }
            public string metode_pembayaran { get; set; }

            public MasterPelanggan MasterPelanggan { get; set; }
            public MasterMeja MasterMeja { get; set; }
            public User User { get; set; }
            public MasterMenu MasterMenu { get; set; }
        }

    }
