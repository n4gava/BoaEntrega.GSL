using BoaEntrega.GSL.Cadastros.Domain;
using EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.GSL.Core.IntegrationEvents
{
    public class ClienteInseridoEvent : IntegrationEvent
    {
        public ClienteInseridoEvent(Guid uid, Cliente cliente)
        {
            this.Cliente = cliente;
            this.Uid = uid;
        }

        public Guid Uid { get; set; }

        public Cliente Cliente { get; set; }
    }
}
