using AutoMapper;
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

        public virtual async Task<bool> Adicionar(Guid uid, T entity)
        {
            _repository.Adicionar(entity);
            return await _repository.UnitOfWork.Commit();
        }

        public virtual async Task<bool> Atualizar(Guid uid, Guid id, T entity)
        {
            var currentEntity = _repository.ObterPorId(id);
            if (currentEntity == null)
                return false;

            entity.Id = currentEntity.Id;
            _repository.Atualizar(entity);
            return await _repository.UnitOfWork.Commit();
        }


        public virtual async Task<bool> Excluir(Guid uid, Guid id)
        {
            var cliente = _repository.ObterPorId(id);
            if (cliente == null)
                return true;

            _repository.Remover(cliente);
            return await _repository.UnitOfWork.Commit();
        }

        public virtual T ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual IQueryable<T> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
