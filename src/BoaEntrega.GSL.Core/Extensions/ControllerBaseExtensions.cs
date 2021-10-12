using Microsoft.AspNetCore.Mvc;
using System;

namespace BoaEntrega.GSL.Core.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static Guid GetUid(this ControllerBase controllerBase)
        {
            var uid = controllerBase.HttpContext.Request.Headers["uid"];
            if (string.IsNullOrEmpty(uid))
                return Guid.Empty;

            return Guid.Parse(uid);
        }
    }
}
