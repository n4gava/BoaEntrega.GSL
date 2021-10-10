using BoaEntrega.GSL.Core.DomainObjects;
using System;

namespace BoaEntrega.GSL.Mercadorias.WebApi.ViewModel
{
    public class AdicionarMercadoriaViewModel
    {
        /// <summary>
        /// Descrição da mercadoria
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Peso da mercadoria
        /// </summary>
        public float Peso { get; set; }

        /// <summary>
        /// ID do depósito de entrada
        /// </summary>
        public Guid DepositoId { get; set; }

        /// <summary>
        /// Endereco de Entrega
        /// </summary>
        public Endereco EnderecoEntrega { get; set; }
    }
}
