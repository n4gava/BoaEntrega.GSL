using BoaEntrega.GSL.Core.DomainObjects;
using System;

namespace BoaEntrega.GSL.Mercadorias.WebApi.ViewModel
{
    public class DepositoViewModel
    {
        /// <summary>
        /// Id do depósito
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Código do depósito
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Descrição do depósito
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Endereço do depósito
        /// </summary>
        public Endereco Endereco { get; set; }

        /// <summary>
        /// Capacidade Máxima
        /// </summary>
        public float CapacidadeMaxima { get; set; }
    }
}
