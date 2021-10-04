using System;
using System.Collections.Generic;
using System.Linq;

using BookService.Helpers;
using BookService.Models;

using Microsoft.AspNetCore.Mvc;

namespace BoaEntrega.GSL.Cadastros.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly static List<Cliente> CLIENTES = ClientesFactoryHelper.CreateClientes().ToList();

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return CLIENTES;
        }

        [HttpGet("{id:guid}")]
        public Cliente Get(Guid id)
        {
            return CLIENTES.Where(b => b.Id == id).SingleOrDefault();
        }
    }
}