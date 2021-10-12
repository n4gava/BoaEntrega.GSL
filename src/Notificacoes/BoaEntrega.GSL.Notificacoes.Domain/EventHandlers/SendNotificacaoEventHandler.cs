using BoaEntrega.GSL.Core.IntegrationEvents;
using BoaEntrega.GSL.Notificacoes.Domain.Services;
using EventBus;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Notificacoes.Domain.EventHandlers
{
    public class SendNotificacaoEventHandler : IIntegrationEventHandler<SendNotificacao>
    {
        private readonly INotificacaoServices _notificacaoServices;

        public SendNotificacaoEventHandler(INotificacaoServices notificacaoServices)
        {
            _notificacaoServices = notificacaoServices;
        }

        public async Task Handle(SendNotificacao @event)
        {
            var notificacao = new Notificacao(@event.Uid, @event.Message, (NotificacaoType)@event.Type);
            await _notificacaoServices.Adicionar(@event.Uid, notificacao);
        }
    }
}
