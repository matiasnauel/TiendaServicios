using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.aplicacion;
using TiendaServicio.api.Autor.modelo;

namespace TiendaServicio.api.Autor.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]

    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> GetAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDTO>> GetAutorLibro(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico { AutorGuid = id });
        }
    }
}
