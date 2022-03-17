using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaServicio.Api.Libro.Aplicacion;
using TiendaServicio.Api.Libro.Modelo;

namespace TiendaServicio.Api.Libro.Tests
{
    public class MappingTests : Profile
    {
        public MappingTests()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTo>();
        }
    }
}
