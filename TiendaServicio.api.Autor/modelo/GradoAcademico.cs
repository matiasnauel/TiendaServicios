using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.api.Autor.modelo
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { get; set; }
        public int NombreGrado { get; set; }
        public string CentroAcademico {get;set;}
        public DateTime? FechaGrado { get; set; }
        public int AutoLibroId { get; set; }

        public AutorLibro AutoLibro { get; set; }
        public string GradoAcademicoGuid { get; set; }
    }

}
