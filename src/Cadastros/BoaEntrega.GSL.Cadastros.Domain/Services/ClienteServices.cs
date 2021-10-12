using BoaEntrega.GSL.Core.Application;
using BoaEntrega.GSL.Core.IntegrationEvents;
using EventBus;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Cadastros.Domain.Services
{
    public class ClienteServices : BaseEntityServices<Cliente>, IClienteServices
    {
        private readonly IEventBus _eventBus;

        public ClienteServices(IClienteRepository clienteRepository, IEventBus eventBus) : base(clienteRepository)
        {
            _eventBus = eventBus;
        }

        public override Task<bool> Adicionar(Guid uid, Cliente cliente)
        {
            _eventBus.Publish(new ClienteInseridoEvent(uid, cliente));
            return Task.FromResult(true);
        }

        public override Task<bool> Atualizar(Guid uid, Guid id, Cliente cliente)
        {
            _eventBus.Publish(new ClienteAtualizadoEvent(uid, cliente));
            return Task.FromResult(true);
        }

        public override Task<bool> Excluir(Guid uid, Guid id)
        {
            _eventBus.Publish(new ClienteRemovidoEvent(uid, id));
            return Task.FromResult(true);
        }
    }
}
