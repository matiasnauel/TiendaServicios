using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.modelo;

namespace TiendaServicio.api.Autor.persistencia
{
    public class DbContextAutor : DbContext
    {
        public DbContextAutor(DbContextOptions<DbContextAutor> options) : base(options) { }
        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }

    }
}
