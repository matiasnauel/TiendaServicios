using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Modelo;

namespace TiendaServicio.Api.CarritoCompra.Persistencia
{
    public class CarritoContexto : DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> option):base(option)
        {

        }
        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }

    }
}
