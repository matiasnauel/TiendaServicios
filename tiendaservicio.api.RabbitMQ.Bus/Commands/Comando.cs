using System;
using System.Collections.Generic;
using System.Text;
using tiendaservicio.api.RabbitMQ.Bus.Events;

namespace tiendaservicio.api.RabbitMQ.Bus.Commands
{
    public abstract class Comando : Message
    {

        public DateTime Timestamp { get; protected set; }
        public Comando()
        {
            Timestamp = DateTime.Now;
        }
    }
}
