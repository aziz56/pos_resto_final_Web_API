using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.BLL.DTO;
using pos.DAL.Interface;
using pos.BLL.Interface;

namespace pos.BLL
{
    public class TransaksiBLL: ITransaksiBLL
    {
        private readonly ITransaksiPenjualan _transaksiPenjualan;
        public TransaksiBLL()
        {
            _transaksiPenjualan = new pos.DAL.DAL.TransaksiPenjualan();
        }
        public void InsertPayment(DTO.TransactionCreateDTO transactionCreateDTO)
        {
            _transaksiPenjualan.InsertPayment(new BO.TransactionData
            {
                
                nama_pelanggan = transactionCreateDTO.nama_pelanggan,
                harga_menu = transactionCreateDTO.harga_menu,
                jumlah_pesanan = transactionCreateDTO.jumlah_pesanan,
                amount = transactionCreateDTO.amount,
                id_menu = transactionCreateDTO.id_menu,
                id_meja =transactionCreateDTO.id_meja
            });            
        }
        public MasterMenuDTO GetHargaByMenu(MasterMenuDTO masterMenuDTO)
        {
            var result = _transaksiPenjualan.GetHargaByMenu(new BO.MasterMenu
            {
                id_menu = masterMenuDTO.id_menu
            });
            return new MasterMenuDTO
            {
                harga_menu = result.harga_menu
            };
           
        }
        public IEnumerable<TransactionDataDTO> GetTransaksiPenjualan()
        {
            var allTransaksi = _transaksiPenjualan.GetTransaksiPenjualan();
            List<TransactionDataDTO> listTransaksi = new List<TransactionDataDTO>();
            foreach (var item in allTransaksi)
            {
                listTransaksi.Add(new TransactionDataDTO
                {
                    id_penjualan = item.id_penjualan,
                    nama_pelanggan = item.nama_pelanggan,
                    nama_menu = item.nama_menu,
                    harga_menu = item.harga_menu,
                    no_meja = item.no_meja,
                    jumlah_pesanan = item.jumlah_pesanan,
                    total_penjualan = item.total_penjualan,
                    kembalian = item.kembalian,
                    amount = item.amount
                });
            }
            return listTransaksi;
    
        }



    }
}
