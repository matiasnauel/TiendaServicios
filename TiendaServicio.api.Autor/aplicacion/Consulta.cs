using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.helper;
using TiendaServicio.api.Autor.modelo;
using TiendaServicio.api.Autor.persistencia;

namespace TiendaServicio.api.Autor.aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDTO>>
        {

        }
        //primer cambio SRP (principio de responsabilidad unica)
        //una clase debe tener solo una razon para cambiar 
        //el sistema de logs se desacoplo de la clase, creando una clase externa, de esta manera si el dia de mañana
        //quiero usar log4net o serilog, solo modifico esa clase y no esta.
        public class Manejador : IRequestHandler<ListaAutor, List<AutorDTO>>
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

            public async Task<List<AutorDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                _logger.Info($"Consulta la lista de los autores");
                List<AutorDTO> autoresDTO = new List<AutorDTO>();
                try
                {
                    List<AutorLibro> autores = await _contexto.AutorLibro.ToListAsync();

                    if (autores != null)
                    {
                        autoresDTO = _mapper.Map<List<AutorLibro>, List<AutorDTO>>(autores);
                        _logger.Info($"Cantidad de autores encontrados: {autoresDTO.Count}");

                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error al buscar los autores: {ex.Message}",ex);
                }
                return autoresDTO;
            }
        }

    }
}
