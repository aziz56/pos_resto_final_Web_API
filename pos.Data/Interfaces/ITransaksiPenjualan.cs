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
        Task<Task> InsertPenjualan(TransaksiPenjualan transaksiPenjualan, TransaksiDetailPenjualan transaksiDetailPenjualan, MasterMenu masterMenu, MasterPelanggan masterPelanggan);
        //Task GetAllTransaksiPenjualan
        Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualan();
        //Task GetHargaByNamaMenu
        Task<MasterMenu> GetHargaByNamaMenu(string namaMenu);
    }
}
