using BoaEntrega.GSL.Core.Data;
using BoaEntrega.GSL.Core.DomainObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Core.Application
{
    public class BaseEntityServices<T> : IEntityServices<T> where T : Entity, IAggregateRoot
    {
        private IRepository<T> _repository;

        public BaseEntityServices(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Adicionar(T entity)
        {
            _repository.Adicionar(entity);
            return await _repository.UnitOfWork.Commit();
        }

        public async Task<bool> Atualizar(Guid id, T entity)
        {
            entity.Id = id;
            _repository.Atualizar(entity);
            return await _repository.UnitOfWork.Commit();
        }


        public async Task<bool> Excluir(Guid id)
        {
            var cliente = _repository.ObterPorId(id);
            if (cliente == null)
                return true;

            _repository.Remover(cliente);
            return await _repository.UnitOfWork.Commit();
        }

        public T ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IQueryable<T> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
