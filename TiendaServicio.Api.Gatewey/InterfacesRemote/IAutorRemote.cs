using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.Gatewey.LibroRemote;

namespace TiendaServicio.Api.Gatewey.InterfacesRemote
{
    public interface IAutorRemote
    {
         Task<(bool resultado, AutorModeloRemote autor, string ErrorMessage)> GetAutor(Guid AutorId);
        
    }
}
