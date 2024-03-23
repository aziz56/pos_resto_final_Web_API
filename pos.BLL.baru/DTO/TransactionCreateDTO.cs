using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BLL.DTO
{
    public class TransactionCreateDTO
    {
      
        public string nama_pelanggan { get; set; }
        public decimal harga_menu { get; set; }
        public int jumlah_pesanan { get; set; }
   
        public decimal amount { get; set; }
        public int id_menu { get; set; }
  
        public int id_meja { get; set; }
    }
}
