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
        //public Task<MasterMenu> GetHargaByNamaMenu(string namaMenu)
        //{
        //    var menu = _context.MasterMenus.FirstOrDefaultAsync(m => m.NamaMenu == namaMenu);
        //    return menu;
            
        //}
        //
        //GetTransaksiByPelanggan
        //public async Task<IEnumerable<TransaksiPenjualan>> GetTransaksiByPelanggan(string namaPelanggan)
        //{
        //    try
        //    {
        //        var getTransaksi = from transaksiPenjualan in _context.TransaksiPenjualans
        //                           join transaksiDetailPenjualan in _context.TransaksiDetailPenjualans
        //                           on transaksiPenjualan
        //                           .IdPenjualan equals transaksiDetailPenjualan.IdPenjualan into detailPenjualanGroup
        //                           from detailPenjualan in detailPenjualanGroup.DefaultIfEmpty()
        //                           join masterPelanggan in _context.MasterPelanggans
        //                           on transaksiPenjualan.IdPelanggaan equals masterPelanggan.IdPelanggan into pelangganGroup
        //                           from pelanggan in pelangganGroup.DefaultIfEmpty()
        //                           join masterMenu in _context.MasterMenus
        //                           on detailPenjualan.IdMenu equals masterMenu.IdMenu into menuGroup
        //                           from menu in menuGroup.DefaultIfEmpty()
        //                           join masterMeja in _context.MasterMejas
        //                           on transaksiPenjualan.IdMeja equals masterMeja.IdMeja into mejaGroup
        //                           from meja in mejaGroup.DefaultIfEmpty()
        //                              where pelanggan.NamaPelanggan == namaPelanggan
        //                              select new TransaksiPenjualan
        //                              {

                                      
        //                              }
        //    }
        //}
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
        //GetTransaksiByNamaPelanggan
        //public async Task<IEnumerable<TransaksiPenjualan>> GetTransaksiByNamaPelanggan(string namaPelanggan)
        //{

        //}

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
        
        //GetAllTransaksiPenjualandanTransaksiDetailPenjualan
        //public async Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualanAndTransaksiDetailPenjualan()
        //{
        //    try
        //    {
        //        var transaksiPenjualans = await _context.TransaksiPenjualans.Include<TransaksiDetailPenjualan>
        //            (t => t.TransaksiDetailPenjualans).ToListAsync();

        //    }
        //}
        public async Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualanAndTransaksiDetailPenjualan()
        {
            var result = from transaksiPenjualan in _context.TransaksiPenjualans
                         join transaksiDetailPenjualan in _context.TransaksiDetailPenjualans
                         on transaksiPenjualan.IdPenjualan equals transaksiDetailPenjualan.IdPenjualan into detailPenjualanGroup
                         from detailPenjualan in detailPenjualanGroup.DefaultIfEmpty()
                         join masterPelanggan in _context.MasterPelanggans
                         on transaksiPenjualan.IdPelanggaan equals masterPelanggan.IdPelanggan into pelangganGroup
                         from pelanggan in pelangganGroup.DefaultIfEmpty()
                         join masterMenu in _context.MasterMenus
                         on detailPenjualan.IdMenu equals masterMenu.IdMenu into menuGroup
                         from menu in menuGroup.DefaultIfEmpty()
                         join masterMeja in _context.MasterMejas
                         on transaksiPenjualan.IdMeja equals masterMeja.IdMeja into mejaGroup
                         from meja in mejaGroup.DefaultIfEmpty()
                         select new
                         {
                             NamaPelanggan = pelanggan.NamaPelanggan,
                             TanggalPenjualan = transaksiPenjualan.TanggalPenjualan,
                             WaktuPenjualan = transaksiPenjualan.WaktuPenjualan,
                             TotalPenjualan = transaksiPenjualan.TotalPenjualan,
                             Amount = transaksiPenjualan.Amount,
                             Kembalian = transaksiPenjualan.Kembalian,
                             NamaMenu = menu.NamaMenu,
                             HargaMenu = menu.HargaMenu,
                             NoMeja = meja.NoMeja
                         };

            return (IEnumerable<TransaksiPenjualan>)await result.ToListAsync();

        }

        public async Task<IEnumerable<TransaksiPenjualan>> GetTransaksiByPelanggan(string namaPelanggan)
        {
            try
            {
                var result = from transaksiPenjualan in _context.TransaksiPenjualans
                             join transaksiDetailPenjualan in _context.TransaksiDetailPenjualans
                             on transaksiPenjualan.IdPenjualan equals transaksiDetailPenjualan.IdPenjualan into detailPenjualanGroup
                             from detailPenjualan in detailPenjualanGroup.DefaultIfEmpty()
                             join masterPelanggan in _context.MasterPelanggans
                             on transaksiPenjualan.IdPelanggaan equals masterPelanggan.IdPelanggan into pelangganGroup
                             from pelanggan in pelangganGroup.DefaultIfEmpty()
                             join masterMenu in _context.MasterMenus
                             on detailPenjualan.IdMenu equals masterMenu.IdMenu into menuGroup
                             from menu in menuGroup.DefaultIfEmpty()
                             join masterMeja in _context.MasterMejas
                             on transaksiPenjualan.IdMeja equals masterMeja.IdMeja into mejaGroup
                             from meja in mejaGroup.DefaultIfEmpty()
                             where pelanggan.NamaPelanggan == namaPelanggan // Gunakan parameter namaPelanggan sebagai filter
                             select new TransaksiPenjualan // Ubah tipe hasil menjadi TransaksiPenjualan
                             {
                                 IdPenjualan = transaksiPenjualan.IdPenjualan,
                                 TanggalPenjualan = transaksiPenjualan.TanggalPenjualan,
                                 WaktuPenjualan = transaksiPenjualan.WaktuPenjualan,
                                 TotalPenjualan = transaksiPenjualan.TotalPenjualan,
                                 Amount = transaksiPenjualan.Amount,
                                 Kembalian = transaksiPenjualan.Kembalian,
                                 IdMejaNavigation = transaksiPenjualan.IdMejaNavigation, // Gunakan navigasi yang telah dimuat
                                 TransaksiDetailPenjualans = transaksiPenjualan.TransaksiDetailPenjualans // Gunakan detail penjualan yang telah dimuat
                             };

                return await result.ToListAsync(); // Tambahkan await untuk menjalankan kueri LINQ secara asynchronous

            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTransaksiByPelanggan: " + ex.Message);
            }

        }  
        public async Task<Task> InsertTransaksiReservasi(string NamaPelanggan, int IdMeja, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            try
            {
                var insertTransaksi = new TransaksiReservasi()
                {
                   
                    TanggalReservasi = TanggalReservasi,
                    JamReservasi = JamReservasi,
                    IdMeja = IdMeja,
                    IdPelangganNavigation = new MasterPelanggan { NamaPelanggan = NamaPelanggan }
                };
                _context.TransaksiReservasis.Add(insertTransaksi);
                foreach (var item in insertTransaksi)
                {

                }
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            
            }
            catch(Exception ex) 
            {
                throw new Exception("Error in GetTransaksiPenjualan: " + ex.Message);
            }
            
        }
        //get
        public async Task<List<(TransaksiReservasi transaksiReservasi, string namaPelanggan)>> GetAllTransaksiReservasi()
        {
            try
            {
                // Mengambil semua transaksi reservasi dan nama pelanggan yang terkait dari basis data
                var transaksiReservasiList = await _context.TransaksiReservasis
                    .Join(
                        _context.MasterPelanggans, // Tabel MasterPelanggans
                        tr => tr.IdPelanggan, // Kolom yang menjadi kunci asing di TransaksiReservasi
                        mp => mp.IdPelanggan, // Kolom yang menjadi kunci primer di MasterPelanggans
                        (tr, mp) => new { TransaksiReservasi = tr, NamaPelanggan = mp.NamaPelanggan } // Seleksi hasil join
                    ).ToListAsync();

                // Konversi hasil join ke dalam tipe yang diinginkan
                var resultList = transaksiReservasiList.Select(x => (x.TransaksiReservasi, x.NamaPelanggan)).ToList();

                return resultList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllTransaksiReservasi: " + ex.Message);
            }
        }



    }
}




