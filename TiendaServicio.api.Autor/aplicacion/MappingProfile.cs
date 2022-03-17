using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.modelo;

namespace TiendaServicio.api.Autor.aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDTO>();
        }
    }
}
