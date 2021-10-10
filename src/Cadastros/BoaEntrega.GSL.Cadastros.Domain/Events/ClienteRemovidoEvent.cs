using BoaEntrega.GSL.Cadastros.Domain;
using EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.GSL.Core.IntegrationEvents
{
    public class ClienteRemovidoEvent : IntegrationEvent
    {
        public ClienteRemovidoEvent(Guid uid, Guid clienteId)
        {
            this.ClienteId = clienteId;
            this.Uid = uid;
        }

        public Guid Uid { get; set; }

        public Guid ClienteId { get; set; }
    }
}
