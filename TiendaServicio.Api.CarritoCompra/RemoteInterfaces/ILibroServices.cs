using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.RemoteModel;

namespace TiendaServicio.Api.CarritoCompra.RemoteInterfaces
{
    public interface ILibroServices
    {
        Task<(bool resultado, LibroRemote libro, string ErrorMessage)> GetLibro(Guid LibroId);
        
    }
}
