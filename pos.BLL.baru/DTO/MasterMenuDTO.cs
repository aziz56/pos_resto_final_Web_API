using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BLL.DTO
{
    public class MasterMenuDTO
    {
        public int id_menu { get; set; }
        public string nama_menu { get; set; }
        public decimal harga_menu { get; set; }
        public string deskripsi_menu { get; set; }
    }
}
