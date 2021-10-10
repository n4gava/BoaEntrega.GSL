using BoaEntrega.GSL.Core.Data;
using BoaEntrega.GSL.Mercadorias.Domain;

namespace BoaEntrega.GSL.Mercadorias.Data.Repositories
{
    public class DepositoRepository : BaseEntityRepository<Deposito>, IDepositoRepository
    {
        public DepositoRepository(MercadoriaContext context) : base(context, context)
        {
        }
    }
}
