using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.modelo;

namespace TiendaServicio.api.Autor.aplicacion
{
    public class AutorDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
