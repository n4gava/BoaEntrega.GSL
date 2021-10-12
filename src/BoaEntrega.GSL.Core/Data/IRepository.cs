using BoaEntrega.GSL.Core.DomainObjects;
using System;
using System.Linq;

namespace BoaEntrega.GSL.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        void Adicionar(T cliente);

        void Atualizar(T cliente);

        void Remover(T cliente);

        T ObterPorId(Guid id);

        IQueryable<T> ObterTodos();
    }
}
