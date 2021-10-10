using BoaEntrega.GSL.Core.Extensions;
using BoaEntrega.GSL.Notificacoes.Domain.Services;
using EventBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System;

namespace BoaEntrega.GSL.Notificacoes.Controllers
{
    [ApiController]
    [Route("api/notificacoes")]
    public class NotificacoesController : ControllerBase
    {
        private readonly INotificacaoServices _notificacaoServices;

        public NotificacoesController(INotificacaoServices notificacaoServices)
        {
            _notificacaoServices = notificacaoServices;
        }

        /// <summary>
        /// Retorna as notificações para o usuário
        /// </summary>
        /// <returns>notificações para o usuário</returns>
        [ODataAttributeRouting]
        [EnableQuery(PageSize = 100)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_notificacaoServices.ObterPorUsuario(this.GetUid()));
        }

        /// <summary>
        /// Retorna a notificação pelo Id
        /// </summary>
        /// <param name="id">Id da notificação</param>
        /// <returns>Notificacao</returns>
        [HttpGet("{id:guid}")]
        public virtual IActionResult Get(Guid id)
        {
            var entity = _notificacaoServices.ObterPorId(id);

            if (entity == null || entity.Uid != this.GetUid())
                return NotFound();

            return Ok(entity);
        }

    }
}