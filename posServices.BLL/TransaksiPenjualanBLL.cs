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
        public TransaksiPenjualanBLL(ITransaksiPenjualan transaksiPenjualan)
        {
            _transaksiPenjualan = transaksiPenjualan;
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
        //GetAllTransaction
        public async Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualanAndTransaksiDetailPenjualan()
        {
            try
            {
                var result = await _transaksiPenjualan.GetAllTransaksiPenjualanAndTransaksiDetailPenjualan();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllTransaksiPenjualanAndTransaksiDetailPenjualan: " + ex.Message);
            }
           
        }
        //GetTransaksiByPelanggan(string namaPelanggan)
        public async Task<IEnumerable<TransaksiPenjualan>> GetTransaksiByPelanggan(string namaPelanggan)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTransaksiByPelanggan(namaPelanggan);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTransaksiByPelanggan: " + ex.Message);
            }
        }
        //GetHargaByNamaMenu
        public async Task<decimal> GetHargaMenuById(int idMenu)
        {
            try
            {
                var result = await _transaksiPenjualan.GetHargaMenuById(idMenu);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetHargaMenuById: " + ex.Message);
            }
        }
        //GetAllTransaksiPenjualan
        public async Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualan()
        {
            try
            {
                var result = await _transaksiPenjualan.GetAllTransaksiPenjualan();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllTransaksiPenjualan: " + ex.Message);
            }
        }
        //InsertTransaksiReservasi(List<TransaksiDetailReservasi> detailReservasi, string NamaPelanggan, DateTime TanggalReservasi, TimeOnly JamReservasi)
        public async Task<Task> InsertTransaksiReservasi(List<TransaksiDetailReservasi> detailReservasi, string NamaPelanggan, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            try
            {
                await _transaksiPenjualan.InsertTransaksiReservasi(detailReservasi, NamaPelanggan, TanggalReservasi, JamReservasi);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                    throw new Exception("Error in InsertTransaksiReservasi: " + ex.Message);
            }
        }
        //GetAllTransaksiReservasi()
        public async Task<List<(TransaksiReservasi transaksiReservasi, string namaPelanggan)>> GetAllTransaksiReservasi()
        {
            try
            {
                var result = await _transaksiPenjualan.GetAllTransaksiReservasi();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllTransaksiReservasi: " + ex.Message);
            }
        }
        //GetCountTotalTransaction()
        public async Task<int> GetCountTotalTransaction()
        {
            try
            {
                var result = await _transaksiPenjualan.GetCountTotalTransaction();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCountTotalTransaction: " + ex.Message);
            }
        }
        //GetCountTotalTransactionByDate(DateOnly date)
        public async Task<int> GetCountTotalTransactionByDate(DateOnly date)
        {
            try
            {
                var result = await _transaksiPenjualan.GetCountTotalTransactionByDate(date);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCountTotalTransactionByDate: " + ex.Message);
            }
        }
        //GetTop5MenuByTransaction()
        public async Task<IEnumerable<(string NamaMenu, int JumlahPesanan)>> GetTop5MenuByTransaction()
        {
            try
            {
                var result = await _transaksiPenjualan.GetTop5MenuByTransaction();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTop5MenuByTransaction: " + ex.Message);
            }
        }
        //GetTotalTransactionByMenu(string namaMenu)
        public async Task<decimal> GetTotalTransactionByMenu(string namaMenu)
        {
                try
            {
                var result = await _transaksiPenjualan.GetTotalTransactionByMenu(namaMenu);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalTransactionByMenu: " + ex.Message);
            }
        }
        //GetTotalTransactionByPelanggan(string namaPelanggan)
        public async Task<decimal> GetTotalTransactionByPelanggan(string namaPelanggan)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalTransactionByPelanggan(namaPelanggan);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalTransactionByPelanggan: " + ex.Message);
            }
        }
        //GetTotalBalanceByDate(DateOnly date)
        public async Task<decimal> GetTotalBalanceByDate(DateOnly date)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalBalanceByDate(date);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalBalanceByDate: " + ex.Message);
            }
        }
        //GetTotalBalance
        public async Task<decimal> GetTotalBalance()
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalBalance();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalBalance: " + ex.Message);
            }
        }

        public Task InsertPenjualan(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<Task> InsertTransaksiReservasi(string NamaPelanggan, int IdMeja, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            throw new NotImplementedException();
        }
    }
}
