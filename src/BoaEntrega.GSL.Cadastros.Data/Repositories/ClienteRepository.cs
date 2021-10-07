using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Core.Data;

namespace BoaEntrega.GSL.Cadastros.Data.Repositories
{
    public class ClienteRepository : BaseEntityRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CadastrosContext context) : base(context, context)
        {
        }
    }
}
