using Microsoft.AspNetCore.Mvc;
using PricingService.Helpers;
using PricingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoaEntrega.GSL.Mercadorias.Controllers
{
    [ApiController]
    [Route("api/mercadorias")]
    public class MercadoriasController : ControllerBase
    {
        private static readonly IEnumerable<Mercadoria> MERCADORIAS = MercadoriasFactoryHelper.CreateMercadorias().ToList();


        [HttpGet]
        public IEnumerable<Mercadoria> Get()
        {
            return MERCADORIAS;
        }

        [HttpGet("{id:guid}")]
        public Mercadoria Get(Guid id)
        {
            return MERCADORIAS.Where(bp => bp.Id == id).SingleOrDefault();
        }
    }
}