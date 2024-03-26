using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;

namespace posServices.Data.Interfaces
{
    public interface ITransaksiPenjualan 
    {
        //InsertPenjualan dan InsertDetailPenjualan
        Task InsertPenjualan(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount);
        //Task GetAllTransaksiPenjualan
        Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualan();
        //Task GetHargaByNamaMenu
        Task<decimal> GetHargaMenuById(int idMenu);
        Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualanAndTransaksiDetailPenjualan();
        //GetTransaksiByPelanggan
        Task<IEnumerable<TransaksiPenjualan>> GetTransaksiByPelanggan(string namaPelanggan);
        Task<Task> InsertTransaksiReservasi(string NamaPelanggan, int IdMeja, DateTime TanggalReservasi, TimeOnly JamReservasi);

    }
}
