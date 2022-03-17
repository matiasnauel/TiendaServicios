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
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDTO>>
        {

        }
        public class Manejador : IRequestHandler<ListaAutor, List<AutorDTO>>
        {
            private readonly DbContextAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(DbContextAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<AutorDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();
                var autoresDTO = _mapper.Map<List<AutorLibro>, List<AutorDTO>>(autores);
                return autoresDTO;
            }
        }

    }
}
