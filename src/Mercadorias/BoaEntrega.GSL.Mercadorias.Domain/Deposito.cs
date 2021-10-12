using BoaEntrega.GSL.Core.DomainObjects;
using System.Collections;
using System.Collections.Generic;

namespace BoaEntrega.GSL.Mercadorias.Domain
{
    public class Deposito : Entity, IAggregateRoot
    {
        public int Codigo { get; set; }


        public string Descricao { get; set; }

        public List<Mercadoria> Mercadorias { get; set; } = new List<Mercadoria>();

        public Endereco Endereco { get; set; }

        public float CapacidadeMaxima { get; set; }

        public float CapacidadeAlocada { get; set; }

        public void AdicionarMercadoria(Mercadoria mercadoria)
        {
            Mercadorias.Add(mercadoria);
            CapacidadeAlocada += mercadoria.Peso;
        }

        public void RemoverMercadoria(Mercadoria mercadoria)
        {
            Mercadorias.Remove(mercadoria);
            CapacidadeAlocada -= mercadoria.Peso;
        }
    }
}
