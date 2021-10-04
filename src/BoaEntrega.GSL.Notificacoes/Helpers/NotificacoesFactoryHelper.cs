using BoaEntrega.GSL.Notificacoes.Enums;
using BoaEntrega.GSL.Notificacoes.Models;
using System;
using System.Collections.Generic;

namespace RatingService.Helpers
{
    public static class NotificacoesFactoryHelper
    {
        public static List<Notificacao> CreateNotificacoes()
        {
            var randomSeconds = new Random(100).Next(1, 100);
            return new List<Notificacao>
            {
                new Notificacao
                {
                    Date = DateTimeOffset.Now.Subtract(TimeSpan.FromSeconds(randomSeconds)),
                    Message = "Cliente atualizado com sucesso",
                    Type = NotificacaoType.Info
                }
            };
        }
    }
}