using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicio.Api.Gatewey.InterfacesRemote;
using TiendaServicio.Api.Gatewey.LibroRemote;

namespace TiendaServicio.Api.Gatewey.ImplementRemote
{
    public class AutorRemote : IAutorRemote
    {
        private readonly IHttpClientFactory _httpclient;
        private readonly ILogger<AutorRemote> _logger;

        public AutorRemote(IHttpClientFactory httpclient, ILogger<AutorRemote> logger)
        {
            _httpclient = httpclient;
            _logger = logger;
        }

        public async  Task<(bool resultado, AutorModeloRemote autor, string ErrorMessage)> GetAutor(Guid AutorId)
        {
            try
            {
                var cliente = _httpclient.CreateClient("AutorService");
                var response = await cliente.GetAsync($"/autor/{AutorId}");
                if(response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<AutorModeloRemote>(contenido, options);
                    return (true, resultado,null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e )
            {

                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
