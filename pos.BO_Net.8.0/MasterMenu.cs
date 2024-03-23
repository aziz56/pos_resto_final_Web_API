using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class MasterMenu
    {
        public MasterMenu()
        {
            this.TransaksiPenjualans = new List<TransaksiPenjualan>();
            this.TransaksiReservasis = new List<TransaksiReservasi>();
        }

        public int id_menu { get; set; }
        public string nama_menu { get; set; }
        public decimal harga_menu { get; set; }
        public string deskripsi_menu { get; set; }

        public IEnumerable<TransaksiPenjualan> TransaksiPenjualans { get; set; }
        public IEnumerable<TransaksiReservasi> TransaksiReservasis { get; set; }

    }
}
