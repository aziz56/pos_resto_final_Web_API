using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using posServices.Domain;
using posServices.Domain.Models;

namespace posServices.BLL.DTOs
{
    public class TransaksiReservasiDTO
    {

        public int IdPenjualan { get; set; }
        public string NamaPelanggan { get; set; }
        public DateTime TanggalPenjualan { get; set; }
        public decimal TotalPenjualan { get; set; }
        public decimal Kembalian { get; set; }

        public DateTime TanggalReservasi { get; set; }
        public TimeSpan JamReservasi { get; set; }
    
        public int IdReservasi { get; set; }
        public int IdMenu { get; set; }
        public int IdMeja { get; set; }
      
        public TimeSpan WaktuPenjualan { get; set; }
       
        public decimal Amount { get; set; }
     
        public string NamaMenu { get; set; }
        public decimal HargaMenu { get; set; }
        public int NoMeja { get; set; }

      
        public int JumlahPesanan { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal TotalHarga { get; set; }
    }


}


