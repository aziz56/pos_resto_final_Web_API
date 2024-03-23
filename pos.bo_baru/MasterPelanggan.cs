using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class MasterPelanggan
    {
        public MasterPelanggan()
        {
            this.TransaksiPenjualans = new List<TransaksiPenjualan>();
            this.TransaksiReservasis = new List<TransaksiReservasi>();
        }

        public int id_pelanggan { get; set; }
        public string nama_pelanggan { get; set; }
        public string no_telp_pelanggan { get; set; }
        public string email_pelanggan { get; set; }

        public IEnumerable<TransaksiPenjualan> TransaksiPenjualans { get; set; }
        public IEnumerable<TransaksiReservasi> TransaksiReservasis { get; set; }

    }
}