using BoaEntrega.GSL.Core.DomainObjects;
using System;

namespace BoaEntrega.GSL.Notificacoes.Domain
{
    public class Notificacao : Entity, IAggregateRoot
    {
        public Notificacao(Guid uid, string message, NotificacaoType type)
        {
            Uid = uid;
            Message = message;
            Type = type;
        }
        public string Message { get; set; }

        public Guid Uid { get; set; }

        public NotificacaoType Type { get; set; }
    }
}