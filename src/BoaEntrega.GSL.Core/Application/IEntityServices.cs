using BoaEntrega.GSL.Core.DomainObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Core.Application
{
    public interface IEntityServices<T> : IDisposable where T : Entity, IAggregateRoot
    {
        IQueryable<T> ObterTodos();

        T ObterPorId(Guid id);

        Task<bool> Adicionar(Guid uid, T entity);

        Task<bool> Atualizar(Guid uid, Guid id, T entity);

        Task<bool> Excluir(Guid uid, Guid id);
    }
}
