using AutoMapper;
using BoaEntrega.GSL.Core.Application;
using BoaEntrega.GSL.Core.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Cadastros.WebApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class BaseEntityController<T, TViewModel> : ControllerBase where T : Entity, IAggregateRoot
    {
        private readonly IEntityServices<T> _services;
        private readonly IMapper _mapper;

        public BaseEntityController(IEntityServices<T> services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [ODataAttributeRouting]
        [EnableQuery(PageSize = 100)]
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_services.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public virtual IActionResult Get(Guid id)
        {
            var cliente = _services.ObterPorId(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<T>(clienteViewModel);
            var success = await _services.Adicionar(cliente);
            if (!success)
                return BadRequest();

            return Ok(cliente);
        }

        [HttpPut("{id:Guid}")]
        public virtual async Task<IActionResult> Put(Guid id, TViewModel clienteViewModel)
        {
            var cliente = _services.ObterPorId(id);
            if (cliente == null)
                return NotFound();

            cliente = _mapper.Map(clienteViewModel, cliente);

            var success = await _services.Atualizar(id, cliente);
            if (!success)
                return BadRequest();

            return Ok(cliente);
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var success = await _services.Excluir(id);
            if (!success)
                return BadRequest();

            return Ok();
        }
    }
}