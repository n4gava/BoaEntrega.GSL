using BoaEntrega.GSL.Core.Application;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Mercadorias.Domain.Services
{
    public class DepositoServices : BaseEntityServices<Deposito>, IDepositoServices
    {
        private readonly IDepositoRepository _repository;
        public DepositoServices(IDepositoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<bool> Excluir(Guid uid, Guid id)
        {
            var deposito = _repository.ObterPorId(id);
            if (deposito == null)
                return true;

            if (deposito.Mercadorias.Any())
                throw new Exception("Não é possível excluir um depósito com mercadorias");

            _repository.Remover(deposito);
            return await _repository.UnitOfWork.Commit();
        }
    }
}
