using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tiendaservicio.api.RabbitMQ.Bus.Commands;
using tiendaservicio.api.RabbitMQ.Bus.Events;

namespace tiendaservicio.api.RabbitMQ.Bus.BusRabbit
{
    public interface IRabbitEventBus
    {

        Task EnviarComando<T>(T comando) where T : Comando;

        void Publish<T>(T @evento) where T : Evento;

        void Suscribe<T, TH>() where T : Evento
                               where TH : IEventoManejador<T>;

    }
}
