﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tiendaservicio.api.RabbitMQ.Bus.Events;

namespace tiendaservicio.api.RabbitMQ.Bus.BusRabbit
{
    public interface IEventoManejador<in TEvent> : IEventoManejador where TEvent : Evento
    {
        Task Handle(TEvent @event);
    }

    public interface IEventoManejador
    {

    }

}
