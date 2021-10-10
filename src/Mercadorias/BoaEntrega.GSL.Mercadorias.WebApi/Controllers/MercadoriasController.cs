using AutoMapper;
using BoaEntrega.GSL.Core.Extensions;
using BoaEntrega.GSL.Mercadorias.Domain;
using BoaEntrega.GSL.Mercadorias.Domain.Services;
using BoaEntrega.GSL.Mercadorias.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Mercadorias.Controllers
{
    [ApiController]
    [Route("api/mercadorias")]
    public class MercadoriasController : ControllerBase
    {
        private readonly IMercadoriaServices _mercadoriaServices;
        private readonly IDepositoServices _depositoService;
        private readonly IMapper _mapper;

        public MercadoriasController(IMercadoriaServices mercadoriaServices, IMapper mapper, IDepositoServices depositoService)
        {
            _mercadoriaServices = mercadoriaServices;
            _depositoService = depositoService;
            _mapper = mapper;
        }
        /// <summary>
        /// Retorna os dados das mercadorias
        /// </summary>]
        /// <remarks>
        /// A consulta utiliza OData (Open Data Protocol) para realizar as consultas.
        /// Ver mais em https://www.odata.org/getting-started/
        /// </remarks>
        /// <returns>Lista de mercadorias</returns>
        [ODataAttributeRouting]
        [EnableQuery(PageSize = 100)]
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_mercadoriaServices.ObterTodos());
        }

        /// <summary>
        /// Retorna os dados da mercadoria pelo código de rastreamento
        /// </summary>
        /// <param name="codigoRastreamento">código de ranstreamento</param>
        /// <returns>informações do depósito</returns>
        [HttpGet("{codigoRastreamento}")]
        public IActionResult Get(string codigoRastreamento)
        {
            var mercadoria = _mercadoriaServices.ObterPorCodigoRastreamento(codigoRastreamento);

            if (mercadoria == null)
                return NotFound();

            return Ok(mercadoria);
        }

        /// <summary>
        /// Adiciona uma nova mercadoria
        /// </summary>
        /// <param name="viewModel">Informações da mercadoria</param>
        /// <returns>Código de rastreamento da mercadoria</returns>
        [HttpPost]
        public async Task<IActionResult> Post(AdicionarMercadoriaViewModel viewModel)
        {
            var deposito = _depositoService.ObterPorId(viewModel.DepositoId);
            if (deposito == null)
                return BadRequest("Depósito informado não cadastrado");


            var mercadoria = _mapper.Map<Mercadoria>(viewModel);
            mercadoria.CodigoRastreamento = await _mercadoriaServices.GerarCodigoRastreamento();
            mercadoria.Deposito = deposito;
            mercadoria.DataEntrega = await _mercadoriaServices.CalcularPrevisaoEntrega(mercadoria.Peso, mercadoria.EnderecoEntrega, deposito.Endereco);
            mercadoria.Valor = await _mercadoriaServices.CalcularValor(mercadoria.Peso, mercadoria.EnderecoEntrega, deposito.Endereco);
            await _mercadoriaServices.Adicionar(this.GetUid(), mercadoria);
            return Ok(mercadoria.CodigoRastreamento);
        }
    }
}