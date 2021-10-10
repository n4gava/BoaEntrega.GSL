using BoaEntrega.GSL.Cadastros.Domain;
using EventBus;
using System;

namespace BoaEntrega.GSL.Core.IntegrationEvents
{
    public class ClienteAtualizadoEvent : IntegrationEvent
    {
        public ClienteAtualizadoEvent(Guid uid, Cliente cliente)
        {
            this.Cliente = cliente;
            this.Uid = uid;
        }

        public Guid Uid { get; set; }

        public Cliente Cliente { get; set; }
    }
}
