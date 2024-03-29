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
using System.Net.Mail;
using System.Net;

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
        //InsertTransaksiPenjualanWithTransaksiDetailPenjualan
 

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

        public async Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualanAndTransaksiDetailPenjualan()
        {
            var result = await _context.TransaksiPenjualans
                .Join(
                    _context.TransaksiDetailPenjualans,
                    transaksiPenjualan => transaksiPenjualan.IdPenjualan,
                    transaksiDetailPenjualan => transaksiDetailPenjualan.IdPenjualan,
                    (transaksiPenjualan, transaksiDetailPenjualan) => new { transaksiPenjualan, transaksiDetailPenjualan }
                )
                .ToListAsync();

            // Now you have a collection of anonymous objects with properties transaksiPenjualan and transaksiDetailPenjualan
            // You can map these to your TransaksiPenjualan DTO

            // For example, if you have a mapping logic, you can do something like this:
            var mappedResult = result.Select(item => new TransaksiPenjualan
            {
                // Map properties from transaksiPenjualan
                IdPenjualan = item.transaksiPenjualan.IdPenjualan,
                TanggalPenjualan = item.transaksiPenjualan.TanggalPenjualan,
                WaktuPenjualan = item.transaksiPenjualan.WaktuPenjualan,
                TotalPenjualan = item.transaksiPenjualan.TotalPenjualan,
                Kembalian = item.transaksiPenjualan.Kembalian,
                //GetNamaPelangganByID
                IdPelanggaanNavigation = new MasterPelanggan { NamaPelanggan = item.transaksiPenjualan.IdPelanggaanNavigation.NamaPelanggan },
                TransaksiDetailPenjualans = new List<TransaksiDetailPenjualan> // Create a new list
        {
            new TransaksiDetailPenjualan
            {
                //GetNamaMenuByID
                IdMenuNavigation = new MasterMenu { NamaMenu = item.transaksiDetailPenjualan.IdMenuNavigation.NamaMenu },
                JumlahPesasan = item.transaksiDetailPenjualan.JumlahPesasan,
                HargaMenu = item.transaksiDetailPenjualan.HargaMenu
            }
        }
            });

            return mappedResult;
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
        
        //InsertTransaksiReservasiWithTransaksiDetailReservasi
        //public async Task<>
        public async Task<Task> InsertTransaksiReservasi(List<TransaksiDetailReservasi> detailReservasi, string NamaPelanggan, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            try
            {
                var insertTransaksi = new TransaksiReservasi()
                {

                    TanggalReservasi = TanggalReservasi,
                    JamReservasi = JamReservasi,
                    IdPelangganNavigation = new MasterPelanggan { NamaPelanggan = NamaPelanggan }
                };
                _context.TransaksiReservasis.Add(insertTransaksi);
                foreach (var item in detailReservasi)
                {
                    var transaksiDetail = new TransaksiDetailReservasi
                    {
                        IdReservasi = item.IdReservasi,
                        IdMenu = item.IdMenu,
                        IdMeja = item.IdMeja

                    };
                    _context.TransaksiDetailReservasis.Add(transaksiDetail);

                }
                await _context.SaveChangesAsync();
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTransaksiPenjualan: " + ex.Message);
            }

        }
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

        //Get Count Total Transaction
        public async Task<int> GetCountTotalTransaction()
        {
            try
            {
                var totalTransaction = await _context.TransaksiPenjualans.CountAsync();
                return totalTransaction;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCountTotalTransaction: " + ex.Message);
            }
        }
        //Get Count Total Transaction By Date
        public async Task<int> GetCountTotalTransactionByDate(DateOnly date)
        {
            try
            {
                var totalTransactionByDate = await _context.TransaksiPenjualans
                    .Where(t => t.TanggalPenjualan == date)
                    .CountAsync();
                return totalTransactionByDate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCountTotalTransactionByDate: " + ex.Message);
            }
        }
        //Get Total Transaction By Date
        public async Task<decimal> GetTotalTransactionByDate(DateOnly date)
        {
            try
            {
                var totalTransactionByDate = await _context.TransaksiPenjualans
                    .Where(t => t.TanggalPenjualan == date)
                    .SumAsync(t => t.TotalPenjualan);
                return (decimal)totalTransactionByDate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalTransactionByDate: " + ex.Message);
            }
        }
        //Get Top 5 Menu By Transaction
        public async Task<IEnumerable<(string NamaMenu, int JumlahPesanan)>> GetTop5MenuByTransaction()
        {
            try
            {
                var top5Menu = await _context.TransaksiDetailPenjualans
                    .GroupBy(t => t.IdMenu)
                    .Select(g => new
                    {
                        NamaMenu = g.First().IdMenuNavigation.NamaMenu,
                        JumlahPesanan = g.Sum(t => t.JumlahPesasan)
                    })
                    .OrderByDescending(g => g.JumlahPesanan)
                    .Take(5)
                    .ToListAsync();
                return (IEnumerable<(string NamaMenu, int JumlahPesanan)>)top5Menu.Select(x => (x.NamaMenu, x.JumlahPesanan));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTop5MenuByTransaction: " + ex.Message);
            }
        }
        //GetTotalTransactionByMenu
        public async Task<decimal> GetTotalTransactionByMenu(string namaMenu)
        {
            try
            {
                var totalTransactionByMenu = await _context.TransaksiDetailPenjualans
                    .Where(t => t.IdMenuNavigation.NamaMenu == namaMenu)
                    .SumAsync(t => t.JumlahPesasan * t.HargaMenu);
                return (decimal)totalTransactionByMenu;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in GetTotalTransactionByMenu: " + ex.Message);
            }
        }
        //GetTotalTransactionByPelanggan
        public async Task<decimal> GetTotalTransactionByPelanggan(string namaPelanggan)
        {
            try
            {
                var totalTransactionByPelanggan = await _context.TransaksiPenjualans
                    .Where(t => t.IdPelanggaanNavigation.NamaPelanggan == namaPelanggan)
                    .SumAsync(t => t.TotalPenjualan);
                return (decimal)totalTransactionByPelanggan;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalTransactionByPelanggan: " + ex.Message);
            }
        }
        //GetTotalBalance
        public async Task<decimal> GetTotalBalance()
        {
            try
            {
                var totalBalance = await _context.TransaksiPenjualans
                    .SumAsync(t => t.TotalPenjualan);
                return (decimal)totalBalance;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalBalance: " + ex.Message);
            }
        }
        //GetTotalBalanceByDate
        public async Task<decimal> GetTotalBalanceByDate(DateOnly date)
        {
            try
            {
                var totalBalanceByDate = await _context.TransaksiPenjualans
                    .Where(t => t.TanggalPenjualan == date)
                    .SumAsync(t => t.TotalPenjualan);
                return (decimal)totalBalanceByDate;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetTotalBalanceByDate: " + ex.Message);
            }
        }
        public async Task InsertPenjualanWithInvoice(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount)
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

                // Kirim invoice via email
                await KirimInvoiceViaEmail(transaksiPenjualan);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertPenjualan: " + ex.Message);
            }
        }

        private async Task KirimInvoiceViaEmail(TransaksiPenjualan transaksiPenjualan)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.example.com");

                mail.From = new MailAddress("aziz.abdulaziz99@gmail.com");
                mail.To.Add("akhmad.aini99@gmail.com");
                mail.Subject = "Invoice Pembelian";
                mail.Body = $"Terlampir adalah invoice untuk transaksi dengan ID: {transaksiPenjualan.IdPenjualan}. Total pembelian: {transaksiPenjualan.TotalPenjualan}";

                // Attach invoice file if needed
                // mail.Attachments.Add(new Attachment("invoice.pdf"));

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("your_email@example.com", "your_password");
                SmtpServer.EnableSsl = true;

                await SmtpServer.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in KirimInvoiceViaEmail: " + ex.Message);
            }
        }

        public Task<Task> InsertTransaksiReservasi(string NamaPelanggan, int IdMeja, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            throw new NotImplementedException();
        }
    }
}




