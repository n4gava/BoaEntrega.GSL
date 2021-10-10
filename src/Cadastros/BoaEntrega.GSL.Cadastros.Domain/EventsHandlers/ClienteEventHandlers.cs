using BoaEntrega.GSL.Core.IntegrationEvents;
using EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Cadastros.Domain.EventsHandlers
{
    public class ClienteEventHandlers : 
        IIntegrationEventHandler<ClienteAtualizadoEvent>,
        IIntegrationEventHandler<ClienteRemovidoEvent>,
        IIntegrationEventHandler<ClienteInseridoEvent>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEventBus _eventBus;

        public ClienteEventHandlers(IClienteRepository clienteRepository, IEventBus eventBus)
        {
            _clienteRepository = clienteRepository;
            _eventBus = eventBus;
        }

        public async Task Handle(ClienteAtualizadoEvent @event)
        {
            var cliente = _clienteRepository.ObterPorId(@event.Cliente.Id);
            if (cliente != null)
            {
                @event.Cliente.Codigo = cliente.Codigo;
                _clienteRepository.Atualizar(@event.Cliente);
                await _clienteRepository.UnitOfWork.Commit();
                _eventBus.Publish(new SendNotificacao(@event.Uid, $"Cliente {cliente.Codigo} atualizado com sucesso."));
            }
        }

        public async Task Handle(ClienteRemovidoEvent @event)
        {
            var cliente = _clienteRepository.ObterPorId(@event.ClienteId);
            if (cliente != null)
            {
                _clienteRepository.Remover(cliente);
                await _clienteRepository.UnitOfWork.Commit();
                _eventBus.Publish(new SendNotificacao(@event.Uid, $"Cliente {cliente.Codigo} removido com sucesso."));
            }
        }

        public async Task Handle(ClienteInseridoEvent @event)
        {
            _clienteRepository.Adicionar(@event.Cliente);
            await _clienteRepository.UnitOfWork.Commit();
            _eventBus.Publish(new SendNotificacao(@event.Uid, $"Cliente {@event.Cliente.Codigo} incluído com sucesso."));
        }
    }
}
