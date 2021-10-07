using PricingService.Models;
using System;
using System.Collections.Generic;

namespace PricingService.Helpers
{
    public static class MercadoriasFactoryHelper
    {
        public static IEnumerable<Mercadoria> CreateMercadorias()
        {
            for (int i = 0; i < 50; i++)
            {
                yield return new Mercadoria
                {
                    Peso = new Random(i).Next(1000, 10000) / 100f,
                    CodigoRastreamento = $"FC0000000{i}"
                };
            }
        }
    }
}