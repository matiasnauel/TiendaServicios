using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.helper;
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
            private readonly IMapperCustom _mapper;
            private readonly ILoggin _logger;

            public Manejador(DbContextAutor contexto, IMapperCustom mapper, ILoggin logger)
            {
                _contexto = contexto;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                AutorDTO autorDTO = null;
                _logger.Info($"Inicio la busqueda del Autor {request.AutorGuid}");
                try
                {
                    var autor = await _contexto.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                    if (autor == null)
                    {
                        throw new Exception("No se encontro el autor");
                    }
                    autorDTO = _mapper.Map<AutorLibro, AutorDTO>(autor);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error en la busqueda del Autor {request.AutorGuid} message: {ex.Message}", ex);
                }
                return autorDTO;
            }
        }
    }
}
