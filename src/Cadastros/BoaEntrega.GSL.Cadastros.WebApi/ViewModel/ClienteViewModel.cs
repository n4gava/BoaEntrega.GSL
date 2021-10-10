using BoaEntrega.GSL.Core.DomainObjects;

namespace BoaEntrega.GSL.Cadastros.ViewModel
{
    public class ClienteViewModel
    {
        public string Descricao { get; set; }

        public Endereco Endereco { get; set; }

        public string Observacao { get; set; }
    }
}
