using BoaEntrega.GSL.Core.DomainObjects;
using BoaEntrega.GSL.Notificacoes.Enums;
using System;

namespace BoaEntrega.GSL.Notificacoes.Models
{
    public class Notificacao : Entity
    {
        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }

        public NotificacaoType Type { get; set; }
    }
}