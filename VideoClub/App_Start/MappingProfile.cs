using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VideoClub.DTOs;
using VideoClub.Entities;

namespace VideoClub.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
         
            Mapper.CreateMap<ClienteDTO, Cliente>();
            Mapper.CreateMap<Cliente, ClienteDTO>()
                 .ForMember(c => c.Id, opt => opt.Ignore()); ;


            Mapper.CreateMap<PeliculaDTO, Pelicula>();
            Mapper.CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}