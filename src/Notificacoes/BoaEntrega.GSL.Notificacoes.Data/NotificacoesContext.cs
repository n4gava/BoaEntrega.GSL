using BoaEntrega.GSL.Core.Data;
using BoaEntrega.GSL.Notificacoes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Notificacoes.Data
{
    public class NotificacoesContext : DbContext, IUnitOfWork
    {
        public NotificacoesContext(DbContextOptions<NotificacoesContext> options)
            : base(options) { }

        public DbSet<Notificacao> Notificacoes { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
