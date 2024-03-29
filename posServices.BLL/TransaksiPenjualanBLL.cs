using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.BLL.Interfaces;
using posServices.Data;
using posServices.Data.Interfaces;
using AutoMapper;
using posServices.BLL.DTOs;
using posServices.Domain.Models;

namespace posServices.BLL
{
    public class TransaksiPenjualanBLL : ITransaksiPenjualanBLL
    {
        private readonly ITransaksiPenjualan _transaksiPenjualan;
        //private readonly IMapper _mapper;
        public TransaksiPenjualanBLL(ITransaksiPenjualan transaksiPenjualan/*, IMapper mapper*/)
        {
            _transaksiPenjualan = transaksiPenjualan;
            //_mapper = mapper;
       
            
        }

        public async Task InsertPenjualanWithInvoice(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount)
        {
            try
            {
                await _transaksiPenjualan.InsertPenjualanWithInvoice(namaPelanggan, pesananList, idMeja, amount);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertPenjualanWithInvoice: " + ex.Message);
            }

        }
        public async Task<IEnumerable<(string NamaMenu, int JumlahPesanan)>> GetTop5MenuByTransaction()
        {
            try
            {
                return await _transaksiPenjualan.GetTop5MenuByTransaction();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTop5MenuByTransaction: " + ex.Message);
            }
        }







    }
}
