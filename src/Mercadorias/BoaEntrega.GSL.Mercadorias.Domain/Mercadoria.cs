using BoaEntrega.GSL.Core.DomainObjects;
using System;

namespace BoaEntrega.GSL.Mercadorias.Domain
{
    public class Mercadoria : Entity, IAggregateRoot
    {
        public string CodigoRastreamento { get; set; }

        public string Descricao { get; set; }

        public Endereco EnderecoEntrega { get; set; }

        public float Peso { get; set; }

        public float Valor { get; set; }

        public DateTimeOffset DataEntrega { get; set; }

        public Deposito Deposito { get; set; }
    }
}
