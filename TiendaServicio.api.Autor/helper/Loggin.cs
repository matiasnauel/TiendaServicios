using Microsoft.Extensions.Logging;
using System;

namespace TiendaServicio.api.Autor.helper
{
    public interface ILoggin
    {
        void Info(string message);
        void Error(string message, Exception ex);
        void Fatal(string message, Exception ex);

    }
    public class Loggin : ILoggin
    {
        private readonly ILogger _loggin;
        public Loggin(ILogger<Loggin> loggin)
        {
            _loggin = loggin;
        }
     
        public void Info(string message)
        {
            _loggin.LogInformation(message);
        }
        
        public void Error(string message, Exception ex)
        {
            _loggin.LogError(message, ex);
        }

        public void Fatal(string message, Exception ex)
        {
            _loggin.LogCritical(message, ex);
        }
    }
}
