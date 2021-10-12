using BoaEntrega.GSL.Core.Application;
using System;
using System.Linq;

namespace BoaEntrega.GSL.Notificacoes.Domain.Services
{
    public class NotificacaoServices : BaseEntityServices<Notificacao>, INotificacaoServices
    {
        private readonly INotificacaoRepository _repository;
        public NotificacaoServices(INotificacaoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IQueryable<Notificacao> ObterPorUsuario(Guid uid)
        {
            return _repository.ObterTodos().Where(n => n.Uid == uid);
        }
    }
}
