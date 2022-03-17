using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Modelo;
using TiendaServicio.Api.Libro.Persistencia;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : MediatR.IRequest<LibroMaterialDTo>
        {
            public Guid? LibroId {get;set;}
        }
        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDTo>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDTo> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.LibreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();
                if(libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDTo>(libro);
                return libroDto;
            }
        }
    }
}
