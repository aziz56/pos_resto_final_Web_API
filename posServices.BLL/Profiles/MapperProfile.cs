using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using posServices.BLL.DTOs;
using posServices.Data;

namespace posServices.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<TransaksiPenjualanData, ReservasiDTO>().ReverseMap();
            CreateMap<CreateReservasiDTO, TransaksiPenjualanData>();

        }
    }
}
