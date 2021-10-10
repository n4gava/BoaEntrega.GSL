using BoaEntrega.GSL.Core.Application;
using System;
using System.Linq;

namespace BoaEntrega.GSL.Notificacoes.Domain.Services
{
    public interface INotificacaoServices : IEntityServices<Notificacao>
    {
        IQueryable<Notificacao> ObterPorUsuario(Guid uid);
    }
}
