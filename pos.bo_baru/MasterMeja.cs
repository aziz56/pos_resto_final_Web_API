using System;
using System.Collections.Generic;

namespace pos.BO
{
   
        public class MasterMeja
        {
            public MasterMeja()
            {
                this.TransaksiPenjualans = new List<TransaksiPenjualan>();
                this.TransaksiReservasis = new List<TransaksiReservasi>();
            }

            public int id_meja { get; set; }
            public int? no_meja { get; set; }
            public int? kapasitas_meja { get; set; }
            public string status_meja { get; set; }

            public IEnumerable<TransaksiPenjualan> TransaksiPenjualans { get; set; }
            public IEnumerable<TransaksiReservasi> TransaksiReservasis { get; set; }
        }


    }
