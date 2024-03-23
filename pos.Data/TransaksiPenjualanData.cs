using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;
using posServices.Data.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace posServices.Data
{
    public class TransaksiPenjualanData : ITransaksiPenjualan
    {
        private readonly AppDbContext _context;

        public TransaksiPenjualanData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Task> InsertPenjualan(TransaksiPenjualan entity, TransaksiDetailPenjualan transaksiDetailPenjualan, MasterMenu masterMenu, MasterPelanggan masterPelanggan);
        {
            try
            {
                _context.TransaksiPenjualans.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Task<IEnumerable<TransaksiPenjualan>> GetAllTransaksiPenjualan()
        {
            throw new NotImplementedException();
        }

        public Task<MasterMenu> GetHargaByNamaMenu(string namaMenu)
        {
            throw new NotImplementedException();
        }
    }




 