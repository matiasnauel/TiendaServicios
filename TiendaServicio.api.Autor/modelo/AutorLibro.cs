using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.api.Autor.modelo
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
