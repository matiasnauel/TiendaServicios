using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Modelo;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTo>();
        }
    }
}
