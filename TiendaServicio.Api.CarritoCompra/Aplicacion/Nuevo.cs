using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Modelo;
using TiendaServicio.Api.CarritoCompra.Persistencia;

namespace TiendaServicio.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto contexto;

            public Manejador(CarritoContexto contexto)
            {
                this.contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacionSesion
                };
                contexto.CarritoSesion.Add(carritoSesion);
                var value = await contexto.SaveChangesAsync();
                if (value == 0)
                {
                    throw new Exception("Errores en la inserción");
                }
                int id = carritoSesion.CarritoSesionId;
                foreach (var obj in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj
                    };
                    contexto.CarritoSesionDetalle.Add(detalleSesion);
                }
                value = await contexto.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el detalle del carrito de compras");
            }
        }
    }
}
