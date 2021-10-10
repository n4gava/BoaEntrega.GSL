using EventBus;
using System;

namespace BoaEntrega.GSL.Core.IntegrationEvents
{
    public class SendNotificacao : IntegrationEvent
    {
        public enum NotificacaoType
        {
            Info = 0,
            Error = 1,
            Warn = 2
        }

        public SendNotificacao(Guid uid, string message, NotificacaoType type = NotificacaoType.Info)
        {
            Uid = uid;
            Message = message;
            Type = type;
        }

        public Guid Uid { get; }
        public string Message { get; }
        public NotificacaoType Type { get; }
    }
}
