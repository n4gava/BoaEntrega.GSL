using BoaEntrega.GSL.Core.Data;
using BoaEntrega.GSL.Notificacoes.Domain;

namespace BoaEntrega.GSL.Notificacoes.Data.Repositories
{
    public class NotificacaoRepository : BaseEntityRepository<Notificacao>, INotificacaoRepository
    {
        public NotificacaoRepository(NotificacoesContext context) : base(context, context)
        {
        }
    }
}
