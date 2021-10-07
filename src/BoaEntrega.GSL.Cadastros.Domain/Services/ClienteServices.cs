using BoaEntrega.GSL.Core.Application;

namespace BoaEntrega.GSL.Cadastros.Domain.Services
{
    public class ClienteServices : BaseEntityServices<Cliente>, IClienteServices
    {
        public ClienteServices(IClienteRepository clienteRepository) : base(clienteRepository)
        {

        }
    }
}
