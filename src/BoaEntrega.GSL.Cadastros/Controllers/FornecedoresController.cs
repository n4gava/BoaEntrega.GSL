using AutoMapper;
using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Cadastros.Domain.Services;
using BoaEntrega.GSL.Cadastros.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Cadastros.WebApi.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedoresController : BaseEntityController<Fornecedor, FornecedorViewModel>
    {
        public FornecedoresController(IFornecedorServices fornecedoServices, IMapper mapper) : base(fornecedoServices, mapper)
        {
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
        public override Task<IActionResult> Post(FornecedorViewModel fornecedorViewModel)
        {
            return base.Post(fornecedorViewModel);
        }

        /// <summary>
        /// Altera os dados do fornecedor
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <param name="fornecedorViewModel">informações do fornecedor</param>
        /// <returns></returns>
        public override Task<IActionResult> Put(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            return base.Put(id, fornecedorViewModel);
        }

        /// <summary>
        /// Realiza a exclusão do fornecedor
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <returns></returns>
        public override Task<IActionResult> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}