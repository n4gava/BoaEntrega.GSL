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
    [Route("api/clientes")]
    public class ClientesController : BaseEntityController<Cliente, ClienteViewModel>
    {
        public ClientesController(IClienteServices clienteServices, IMapper mapper) : base(clienteServices, mapper)
        {
        }

        /// <summary>
        /// Retorna os dados de clientes
        /// </summary>]
        /// <remarks>
        /// A consulta utiliza OData (Open Data Protocol) para realizar as consultas.
        /// Ver mais em https://www.odata.org/getting-started/
        /// </remarks>
        /// <returns>Lista de clientes</returns>
        public override IActionResult Get()
        {
            return base.Get();
        }

        /// <summary>
        /// Retorna os dados do cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns>informações do cliente</returns>
        public override IActionResult Get(Guid id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        /// <param name="clienteViewModel">Dados do cliente</param>
        /// <returns></returns>
        public override Task<IActionResult> Post(ClienteViewModel clienteViewModel)
        {
            return base.Post(clienteViewModel);
        }

        /// <summary>
        /// Altera os dados do cliente
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <param name="clienteViewModel">informações do cliente</param>
        /// <returns></returns>
        public override Task<IActionResult> Put(Guid id, ClienteViewModel clienteViewModel)
        {
            return base.Put(id, clienteViewModel);
        }

        /// <summary>
        /// Realiza a exclusão do cliente
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public override Task<IActionResult> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}