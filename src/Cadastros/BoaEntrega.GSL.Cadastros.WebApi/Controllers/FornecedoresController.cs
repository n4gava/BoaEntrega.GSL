using AutoMapper;
using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Cadastros.Domain.Services;
using BoaEntrega.GSL.Cadastros.ViewModel;
using BoaEntrega.GSL.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Cadastros.WebApi.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedoresController : BaseEntityController<Fornecedor, FornecedorViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorServices _fornecedoServices;

        public FornecedoresController(IFornecedorServices fornecedoServices, IMapper mapper) : base(fornecedoServices, mapper)
        {
            _mapper = mapper;
            _fornecedoServices = fornecedoServices;
        }

        /// <summary>
        /// Retorna os dados de fornecedores
        /// </summary>]
        /// <remarks>
        /// A consulta utiliza OData (Open Data Protocol) para realizar as consultas.
        /// Ver mais em https://www.odata.org/getting-started/
        /// </remarks>
        /// <returns>Lista de fornecedores</returns>
        public override IActionResult Get()
        {
            return base.Get();
        }

        /// <summary>
        /// Retorna os dados do fornecedor pelo id
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <returns>informações do fornecedor</returns>
        public override IActionResult Get(Guid id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Adiciona um novo fornecedor
        /// </summary>
        /// <param name="fornecedorViewModel">Dados do fornecedor</param>
        /// <returns></returns>
        public override async Task<IActionResult> Post(FornecedorViewModel fornecedorViewModel)
        {
            var entity = _mapper.Map<Fornecedor>(fornecedorViewModel);
            var success = await _fornecedoServices.Adicionar(this.GetUid(), entity);
            if (!success)
                return BadRequest();

            return Ok(entity);
        }

        /// <summary>
        /// Altera os dados do fornecedor
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <param name="fornecedorViewModel">informações do fornecedor</param>
        /// <returns></returns>
        public override async Task<IActionResult> Put(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            var entity = _fornecedoServices.ObterPorId(id);
            if (entity == null)
                return NotFound();

            entity = _mapper.Map(fornecedorViewModel, entity);

            var success = await _fornecedoServices.Atualizar(this.GetUid(), id, entity);
            if (!success)
                return BadRequest();

            return Ok(entity);
        }

        /// <summary>
        /// Realiza a exclusão do fornecedor
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <returns></returns>
        public override async Task<IActionResult> Delete(Guid id)
        {
            var success = await _fornecedoServices.Excluir(this.GetUid(), id);
            if (!success)
                return BadRequest();

            return Ok();
        }
    }
}