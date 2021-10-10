using BoaEntrega.GSL.Core.Application;

namespace BoaEntrega.GSL.Cadastros.Domain.Services
{
    public class FornecedorServices : BaseEntityServices<Fornecedor>, IFornecedorServices
    {
        public FornecedorServices(IFornecedorRepository fornecedorServices) : base(fornecedorServices)
        {

        }
        
    }
}
