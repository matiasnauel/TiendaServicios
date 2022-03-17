using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.RemoteInterfaces;
using TiendaServicio.Api.CarritoCompra.RemoteModel;

namespace TiendaServicio.Api.CarritoCompra.RemoteServices
{
    public class LibroServices : ILibroServices
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibroServices> _logger;

        public LibroServices(IHttpClientFactory httpClient, ILogger<LibroServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemote libro, string ErrorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                HttpClient cliente = _httpClient.CreateClient("Libros");
                var response = await cliente.GetAsync($"api/LibroMaterial/{LibroId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var results = JsonSerializer.Deserialize<LibroRemote>(contenido, options);
                    return (true, results, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
