using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.Api.Gatewey.LibroRemote
{
    public class AutorModeloRemote
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
