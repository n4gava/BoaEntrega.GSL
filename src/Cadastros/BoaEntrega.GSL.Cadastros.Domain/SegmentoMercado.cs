using BoaEntrega.GSL.Core.DomainObjects;

namespace BoaEntrega.GSL.Cadastros.Domain
{
    public class SegmentoMercado : Entity, IAggregateRoot
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }
    }
}
