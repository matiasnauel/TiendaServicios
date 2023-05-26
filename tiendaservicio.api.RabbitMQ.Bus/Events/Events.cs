using System;
using System.Collections.Generic;
using System.Text;

namespace tiendaservicio.api.RabbitMQ.Bus.Events
{
    public abstract class Evento
    {
        public DateTime Timestap { get; protected set; }
        public Evento()
        {
            Timestap = DateTime.Now;
        }
    }
}
