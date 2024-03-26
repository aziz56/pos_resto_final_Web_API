using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.BLL.DTOs;
using posServices.Domain.Models;

namespace posServices.BLL.Interfaces
{
    public interface ITransaksiPenjualanBLL
    {
        Task<CreateReservasiDTO> InsertTransaksiReservasi(CreateReservasiDTO createReservasiDTO);
        Task<ReservasiDTO> GetAllTransaksiReservasi();


    }
}
