using AutoMapper;
using BoaEntrega.GSL.Core.Application;
using BoaEntrega.GSL.Core.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System;
using System.Threading.Tasks;
using BoaEntrega.GSL.Core.Extensions;

namespace BoaEntrega.GSL.Cadastros.WebApi.Controllers
{
    [ApiController]
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
            var entity = _services.ObterPorId(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TViewModel viewModel)
        {
            var entity = _mapper.Map<T>(viewModel);
            var success = await _services.Adicionar(this.GetUid(), entity);
            if (!success)
                return BadRequest();

            return Accepted();
        }

        [HttpPut("{id:Guid}")]
        public virtual async Task<IActionResult> Put(Guid id, TViewModel viewModel)
        {
            var entity = _mapper.Map<T>(viewModel);
            var success = await _services.Atualizar(this.GetUid(), id, entity);
            if (!success)
                return BadRequest();

            return Accepted();
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var success = await _services.Excluir(this.GetUid(), id);
            if (!success)
                return BadRequest();

            return Accepted();
        }
    }
}