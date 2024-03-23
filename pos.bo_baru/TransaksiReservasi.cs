using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BO
{
    public class TransaksiReservasi
    {
        public int id_reservasi { get; set; }
        public int? id_pelanggan { get; set; }
        public DateTime? tanggal_reservasi { get; set; }
        public TimeSpan? jam_reservasi { get; set; }
        public int? jumlah_orang { get; set; }
        public string keterangan { get; set; }
        public string status_reservasi { get; set; }
        public int? id_menu { get; set; }
        public int? id_meja { get; set; }

        public MasterPelanggan MasterPelanggan { get; set; }
        public MasterMenu MasterMenu { get; set; }
        public MasterMeja MasterMeja { get; set; }
    }
}


