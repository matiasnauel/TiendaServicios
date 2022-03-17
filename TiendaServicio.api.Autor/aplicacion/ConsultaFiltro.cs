using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.modelo;
using TiendaServicio.api.Autor.persistencia;

namespace TiendaServicio.api.Autor.aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDTO>
        {
            public string AutorGuid { get; set; }
        }
        public class Manejador : IRequestHandler<AutorUnico, AutorDTO>
        {

            private readonly DbContextAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(DbContextAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }


            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if (autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var autorDTO = _mapper.Map<AutorLibro, AutorDTO>(autor);
                return autorDTO;
            }
        }
    }
}
