using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Core.Data;

namespace BoaEntrega.GSL.Cadastros.Data.Repositories
{
    public class FornecedorRepository : BaseEntityRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CadastrosContext context) : base(context, context)
        {
        }
    }
}
