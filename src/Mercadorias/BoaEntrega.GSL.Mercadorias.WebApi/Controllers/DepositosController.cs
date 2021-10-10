using AutoMapper;
using BoaEntrega.GSL.Core.Extensions;
using BoaEntrega.GSL.Mercadorias.Domain;
using BoaEntrega.GSL.Mercadorias.Domain.Services;
using BoaEntrega.GSL.Mercadorias.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Mercadorias.WebApi.Controllers
{
    [ApiController]
    [Route("api/depositos")]
    public class DepositosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepositoServices _depositoServices;

        public DepositosController(IMapper mapper, IDepositoServices depositoServices)
        {
            _mapper = mapper;
            _depositoServices = depositoServices;
        }

        /// <summary>
        /// Retorna os dados de depositos
        /// </summary>]
        /// <remarks>
        /// A consulta utiliza OData (Open Data Protocol) para realizar as consultas.
        /// Ver mais em https://www.odata.org/getting-started/
        /// </remarks>
        /// <returns>Lista de depósitos</returns>
        [ODataAttributeRouting]
        [EnableQuery(PageSize = 100)]
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_depositoServices.ObterTodos());
        }

        /// <summary>
        /// Retorna os dados de depósito pelo id
        /// </summary>
        /// <param name="id">id do depósito</param>
        /// <returns>informações do depósito</returns>
        [HttpGet("{id:guid}")]
        public virtual IActionResult Get(Guid id)
        {
            var entity = _depositoServices.ObterPorId(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// Adiciona um novo depósito
        /// </summary>
        /// <param name="viewModel">Dados do depósito</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(DepositoViewModel viewModel)
        {
            var deposito = _mapper.Map<Deposito>(viewModel);
            var success = await _depositoServices.Adicionar(this.GetUid(), deposito);
            if (!success)
                return BadRequest();

            return Ok(deposito);
        }

        /// <summary>
        /// Altera os dados do depósito
        /// </summary>
        /// <param name="id">id do depósito</param>
        /// <param name="viewModel">informações do depósito</param>
        /// <returns></returns>
        [HttpPut("{id:Guid}")]
        public virtual async Task<IActionResult> Put(Guid id, DepositoViewModel viewModel)
        {
            var deposito = _depositoServices.ObterPorId(id);
            if (deposito == null)
                return NotFound();

            deposito = _mapper.Map(viewModel, deposito);
            deposito.Id = id;
            await _depositoServices.Atualizar(this.GetUid(), id, deposito);

            return Ok(deposito);
        }

        /// <summary>
        /// Realiza a exclusão do depósito
        /// </summary>
        /// <param name="id">id do depósito</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var success = await _depositoServices.Excluir(this.GetUid(), id);
            if (!success)
                return BadRequest();

            return Accepted();
        }
    }
}
