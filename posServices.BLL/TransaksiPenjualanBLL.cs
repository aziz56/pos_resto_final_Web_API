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

namespace posServices.BLL
{
    public class TransaksiPenjualanBLL : ITransaksiPenjualanBLL
    {
        private readonly ITransaksiPenjualan _transaksiPenjualan;
        private readonly IMapper _mapper;
        public TransaksiPenjualanBLL(ITransaksiPenjualan transaksiPenjualan, IMapper mapper)
        {
            _transaksiPenjualan = transaksiPenjualan;
            _mapper = mapper;
       
            
        }

        public async Task<ReservasiDTO> GetAllTransaksiReservasi()
        {
            var getAllReservasi = await _transaksiPenjualan.GetAllTransaksiPenjualan();

            return (ReservasiDTO)getAllReservasi;
        }

        public async Task<CreateReservasiDTO> InsertTransaksiReservasi(CreateReservasiDTO createReservasiDTO)
        {
            throw new NotImplementedException();
        }
    }
}
