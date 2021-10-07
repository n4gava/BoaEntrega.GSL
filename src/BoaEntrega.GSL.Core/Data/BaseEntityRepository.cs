using BoaEntrega.GSL.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BoaEntrega.GSL.Core.Data
{
    public class BaseEntityRepository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseEntityRepository(DbContext context, IUnitOfWork unifOfWork)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            UnitOfWork = unifOfWork;
        }

        public IUnitOfWork UnitOfWork { get; private set; }

        public T ObterPorId(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> ObterTodos()
        {
            return _dbSet;
        }


        public void Adicionar(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Atualizar(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remover(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
