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

        Task<bool> Adicionar(T cliente);

        Task<bool> Atualizar(Guid id, T cliente);

        Task<bool> Excluir(Guid id);
    }
}
