using BoaEntrega.GSL.Core.DomainObjects;

namespace BookService.Models
{
    public class Fornecedor : Entity
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
