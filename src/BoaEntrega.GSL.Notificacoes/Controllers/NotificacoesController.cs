using System.Collections.Generic;
using BoaEntrega.GSL.Notificacoes.Models;
using Microsoft.AspNetCore.Mvc;

using RatingService.Helpers;

namespace BoaEntrega.GSL.Notificacoes.Controllers
{
    [ApiController]
    [Route("api/notificacoes")]
    public class NotificacoesController : ControllerBase
    {
        private readonly IEnumerable<Notificacao> _notificacoes;

        public NotificacoesController()
        {
            _notificacoes = NotificacoesFactoryHelper.CreateNotificacoes();
        }

        [HttpGet]
        public IEnumerable<Notificacao> Get()
        {
            return _notificacoes;
        }
    }
}