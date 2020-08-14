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

            //Domain to DTO
            Mapper.CreateMap<Pelicula, PeliculaDTO>();
            Mapper.CreateMap<Cliente, ClienteDTO>();
            Mapper.CreateMap<TipoMembresia, TipoMembresiaDTO>();



            //DTO to Domain

            Mapper.CreateMap<ClienteDTO, Cliente>()
                 .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<PeliculaDTO, Pelicula>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}