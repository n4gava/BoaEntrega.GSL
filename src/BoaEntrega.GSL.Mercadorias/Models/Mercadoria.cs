using BoaEntrega.GSL.Core.DomainObjects;
using System;

namespace PricingService.Models
{
    public class Mercadoria : Entity
    {
        public string CodigoRastreamento { get; set; }

        public float Peso { get; set; }
    }
}