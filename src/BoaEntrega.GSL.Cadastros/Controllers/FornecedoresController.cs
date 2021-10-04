using System;
using System.Collections.Generic;
using System.Linq;

using BookService.Helpers;
using BookService.Models;

using Microsoft.AspNetCore.Mvc;

namespace BoaEntrega.GSL.Cadastros.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedoresController : ControllerBase
    {
        private static readonly List<Fornecedor> FORNECEDORES = FornecedoresFactoryHelper.CreateFornecedores().ToList();


        [HttpGet]
        public IEnumerable<Fornecedor> Get()
        {
            return FORNECEDORES;
        }

        [HttpGet("{id:guid}")]
        public Fornecedor Get(Guid id)
        {
            return FORNECEDORES.Where(b => b.Id == id).SingleOrDefault();
        }
    }
}