using BoaEntrega.GSL.Notificacoes.Models;
using EventBus;
using Microsoft.AspNetCore.Mvc;
using RatingService.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Notificacoes.Controllers
{
    [ApiController]
    [Route("api/notificacoes")]
    public class NotificacoesController : ControllerBase
    {
        private readonly IEnumerable<Notificacao> _notificacoes;
        private readonly IEventBus _eventbus;

        public NotificacoesController(IEventBus eventbus)
        {
            _notificacoes = NotificacoesFactoryHelper.CreateNotificacoes();
            _eventbus = eventbus;
        }

        [HttpGet]
        public IEnumerable<Notificacao> Get()
        {
            _eventbus.Publish(new EventoTeste());
            return _notificacoes;
        }
    }

    public class EventoTeste : IntegrationEvent
    {

    }

    public class EventoTesteHandler : IIntegrationEventHandler<EventoTeste>
    {
        public Task Handle(EventoTeste @event)
        {

            return Task.CompletedTask;
        }
    }
}