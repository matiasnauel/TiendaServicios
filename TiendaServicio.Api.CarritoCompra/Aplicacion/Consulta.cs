using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Persistencia;
using TiendaServicio.Api.CarritoCompra.RemoteInterfaces;

namespace TiendaServicio.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSesionId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibroServices _services;

            public Manejador(CarritoContexto contexto, ILibroServices services)
            {
                _contexto = contexto;
                _services = services;
            }

            public async  Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _contexto.CarritoSesion.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSesionDetalle = await _contexto.CarritoSesionDetalle.Where(x => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();
                var listaCarritoDto = new List<CarritoDetalleDTo>();
                foreach (var item in carritoSesionDetalle)
                {
                    var response =  await _services.GetLibro(new Guid(item.ProductoSeleccionado));
                    if(response.resultado)
                    {
                        var objetoLibro = response.libro;
                        var carritoDetalle = new CarritoDetalleDTo
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        listaCarritoDto.Add(carritoDetalle);
                    }
                 
                }
                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProducto = listaCarritoDto
                };
                return carritoSesionDto;
            }
        }
    }
}
