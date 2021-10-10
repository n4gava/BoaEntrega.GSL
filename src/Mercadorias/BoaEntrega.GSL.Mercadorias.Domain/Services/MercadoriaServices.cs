using BoaEntrega.GSL.Core.Application;
using BoaEntrega.GSL.Core.DomainObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Mercadorias.Domain.Services
{
    public class MercadoriaServices : BaseEntityServices<Mercadoria>, IMercadoriaServices
    {
        Random _random = new Random(DateTimeOffset.Now.Millisecond);
        private readonly IDepositoRepository _depositoRepository;
        private readonly IMercadoriaRepository _repository;

        public MercadoriaServices(IMercadoriaRepository repository, IDepositoRepository depositoRepository) : base(repository)
        {
            _depositoRepository = depositoRepository;
            _repository = repository;
        }

        public override async Task<bool> Adicionar(Guid uid, Mercadoria mercadoria)
        {
            mercadoria.Deposito.AdicionarMercadoria(mercadoria);
            _repository.Adicionar(mercadoria);
            _depositoRepository.Atualizar(mercadoria.Deposito);

            return await _repository.UnitOfWork.Commit();
        }

        public Mercadoria ObterPorCodigoRastreamento(string codigoRastreamento)
        {
            return _repository.ObterTodos().FirstOrDefault(m => m.CodigoRastreamento == codigoRastreamento);
        }

        // O correto desse serviço é utilizar os serviços do SGE (porém isso não está na implementação da POC)
        public Task<DateTime> CalcularPrevisaoEntrega(float peso, Endereco enderecoEntrega, Endereco enderecoDeposito)
        {
            var days = _random.Next(5, 21);
            return Task.FromResult(DateTime.Now.AddDays(days));
        }

        // O correto desse serviço é utilizar os serviços do SGE (porém isso não está na implementação da POC)
        public Task<float> CalcularValor(float peso, Endereco enderecoEntrega, Endereco enderecoDeposito)
        {
            return Task.FromResult(peso * _random.Next(15, 200));
        }

        // O correto desse serviço é utilizar os serviços do SGE (porém isso não está na implementação da POC)
        public Task<string> GerarCodigoRastreamento()
        {
            var nextCode = _random.Next(0, 999999999).ToString();
            return Task.FromResult($"BE{nextCode.PadLeft(9, '0')}BR");
        }


    }
}
