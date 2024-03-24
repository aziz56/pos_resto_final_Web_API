using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;
using posServices.Data.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using posServices.Data;

namespace posServices.Data
{
    public class TransaksiPenjualanData : ITransaksiPenjualan
    {
        private readonly AppDbContext _context;

        public TransaksiPenjualanData(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualan()
        {
            throw new NotImplementedException();
        }

        public Task<MasterMenu> GetHargaByNamaMenu(string namaMenu)
        {
            throw new NotImplementedException();
        }

        //public async Task<Task> InsertPenjualan(TransaksiPenjualan transaksiPenjualan, TransaksiDetailPenjualan transaksiDetailPenjualan, MasterMenu masterMenu, MasterPelanggan masterPelanggan)
        //{

        //    var Penjualan = new TransaksiPenjualan
        //    {
        //        TanggalPenjualan = transaksiPenjualan.TanggalPenjualan = DateOnly.FromDateTime(DateTime.Now),
        //        TotalPenjualan = transaksiPenjualan.TotalPenjualan = SUM(transaksiDetailPenjualan.HargaMenu * transaksiDetailPenjualan.JumlahPesasan),
        //        WaktuPenjualan = transaksiPenjualan.WaktuPenjualan = TimeOnly.FromDateTime(DateTime.Now),
        //        Kembalian = transaksiPenjualan.Kembalian = transaksiPenjualan.Amount - transaksiPenjualan.TotalPenjualan,
        //        Amount = transaksiPenjualan.Amount,
        //        IdPelanggaan = transaksiPenjualan.IdPelanggaan = masterPelanggan.IdPelanggan,

        //    };
        //    List<TransaksiDetailPenjualan> detailPenjualanBaru = new List<TransaksiDetailPenjualan>();

        //    foreach (var item in detailPenjualanBaru)
        //    {
        //        TransaksiDetailPenjualan detailBaru = new TransaksiDetailPenjualan
        //        {
        //            IdMenu = item.IdMenu,

        //            HargaMenu = masterMenu.HargaMenu,
        //            JumlahPesasan = item.JumlahPesasan
        //        };

        //        detailPenjualanBaru.Add(detailBaru);
        //    }
        //    await using var context = new AppDbContext();
        //    context.Database.EnsureCreated();
        //    context.SaveChanges();
        //    return Task.FromResult(Task.CompletedTask);




        //}
        //public async Task InsertPenjualan(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount)
        //{
        //    // Hitung total penjualan dan kembalian
        //    decimal totalPenjualan = pesananList.Sum(pesanan => pesanan.JumlahPesanan * MasterMenu.(m => m.IdMenu == idMenu);
        //    decimal kembalian = amount - totalPenjualan;

        //    // Buat objek TransaksiPenjualan
        //    var transaksiPenjualan = new TransaksiPenjualan
        //    {
        //        TanggalPenjualan = DateOnly.FromDateTime(DateTime.Now),
        //        WaktuPenjualan = TimeOnly.FromDateTime(DateTime.Now),
        //        Amount = amount,
        //        TotalPenjualan = totalPenjualan,
        //        Kembalian = kembalian,
        //        IdMeja = idMeja, // Atur meja yang sesuai
        //        IdPelanggaanNavigation = new MasterPelanggan { NamaPelanggan = namaPelanggan } // Buat objek pelanggan baru
        //    };

        //    // Tambahkan transaksiPenjualan ke dalam konteks
        //    _context.TransaksiPenjualans.Add(transaksiPenjualan);
        //    await _context.SaveChangesAsync(); // Simpan transaksiPenjualan agar mendapatkan IdPenjualan yang baru saja dimasukkan

        //    // Tambahkan setiap item pesanan ke TransaksiDetailPenjualan
        //    foreach (var pesanan in pesananList)
        //    {
        //        var transaksiDetailPenjualan = new TransaksiDetailPenjualan
        //        {
        //            IdMenu = pesanan.IdMenu,
        //            JumlahPesasan = pesanan.JumlahPesanan,
        //            IdPenjualan = transaksiPenjualan.IdPenjualan // Gunakan IdPenjualan yang baru saja dimasukkan
        //        };

        //        // Tambahkan transaksiDetailPenjualan ke dalam konteks
        //        _context.TransaksiDetailPenjualans.Add(transaksiDetailPenjualan);
        //    }
        //    await _context.SaveChangesAsync();
        //}
        public async Task InsertPenjualan(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount)
        {
            try
            {
                // Hitung total penjualan dan kembalian menggunakan LINQ
                decimal totalPenjualan = pesananList.Sum(pesanan =>
                {
                    var hargaMenu = GetHargaMenuById(pesanan.IdMenu).Result; // Menunggu hasil GetHargaMenuById
                    return pesanan.JumlahPesanan * hargaMenu;
                });

                decimal kembalian = amount - totalPenjualan;

                // Buat objek TransaksiPenjualan
                var transaksiPenjualan = new TransaksiPenjualan
                {
                    TanggalPenjualan = DateOnly.FromDateTime(DateTime.Now),
                    WaktuPenjualan = TimeOnly.FromDateTime(DateTime.Now),
                    Amount = amount,
                    TotalPenjualan = totalPenjualan,
                    Kembalian = kembalian,
                    IdMeja = idMeja, // Atur meja yang sesuai
                    IdPelanggaanNavigation = new MasterPelanggan { NamaPelanggan = namaPelanggan } // Buat objek pelanggan baru
                };

                // Tambahkan transaksiPenjualan ke dalam konteks
                _context.TransaksiPenjualans.Add(transaksiPenjualan);
                await _context.SaveChangesAsync(); // Simpan transaksiPenjualan agar mendapatkan IdPenjualan yang baru saja dimasukkan

                // Tambahkan setiap item pesanan ke TransaksiDetailPenjualan
                foreach (var pesanan in pesananList)
                {
                    var transaksiDetailPenjualan = new TransaksiDetailPenjualan
                    {
                        IdMenu = pesanan.IdMenu,
                        JumlahPesasan = pesanan.JumlahPesanan,
                        IdPenjualan = transaksiPenjualan.IdPenjualan // Gunakan IdPenjualan yang baru saja dimasukkan
                    };

                    // Tambahkan transaksiDetailPenjualan ke dalam konteks
                    _context.TransaksiDetailPenjualans.Add(transaksiDetailPenjualan);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertPenjualan: " + ex.Message);
            }
        }

        public async Task<decimal> GetHargaMenuById(int idMenu)
        {
            try
            {
                var menu = await _context.MasterMenus.FirstOrDefaultAsync(m => m.IdMenu == idMenu);
                if (menu == null)
                {
                    throw new ArgumentException("Menu not found");
                }
                return (decimal)menu.HargaMenu;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetHargaMenuById: " + ex.Message);
            }
        }
    }
}




