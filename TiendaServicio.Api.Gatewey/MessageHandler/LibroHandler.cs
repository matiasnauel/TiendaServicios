using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Gatewey.InterfacesRemote;
using TiendaServicio.Api.Gatewey.LibroRemote;

namespace TiendaServicio.Api.Gatewey.MessageHandler
{
    public class LibroHandler : DelegatingHandler
    {
        private readonly ILogger<LibroHandler> logger;
        private readonly IAutorRemote _autoreremote;
        public LibroHandler(ILogger<LibroHandler> logger, IAutorRemote autorRemote)
        {
            this.logger = logger;
            _autoreremote = autorRemote;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationtoken)
        {
            var tiempo = Stopwatch.StartNew();
            logger.LogInformation("Inicia el request");
            var response = await base.SendAsync(request, cancellationtoken);
            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<LibroModeloRemote>(contenido, options);
                var responseAutor = await _autoreremote.GetAutor(resultado.AutorLibro ?? Guid.Empty);
                if (responseAutor.resultado)
                {
                    var objetoAutor = responseAutor.autor;
                    resultado.AutorData = objetoAutor;
                    var resultadoStr = JsonSerializer.Serialize(resultado);
                    response.Content = new StringContent(resultadoStr, System.Text.Encoding.UTF8, "application/json");
                }
            }
            logger.LogInformation($"este proceso se hizo en {tiempo.ElapsedMilliseconds}ms");
            return response;

        }
    }
}
