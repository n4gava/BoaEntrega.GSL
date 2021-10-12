using BoaEntrega.GSL.Core.Application;
using BoaEntrega.GSL.Core.DomainObjects;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Mercadorias.Domain.Services
{
    public interface IMercadoriaServices : IEntityServices<Mercadoria>
    {
        Mercadoria ObterPorCodigoRastreamento(string codigoRastreamento);

        Task<string> GerarCodigoRastreamento();

        Task<float> CalcularValor(float peso, Endereco enderecoEntrega, Endereco enderecoDeposito);

        Task<DateTime> CalcularPrevisaoEntrega(float peso, Endereco enderecoEntrega, Endereco enderecoDeposito);
    }
}
