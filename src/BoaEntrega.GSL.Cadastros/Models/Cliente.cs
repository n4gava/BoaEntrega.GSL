using BoaEntrega.GSL.Core.DomainObjects;
using System;

namespace BookService.Models
{
    public class Cliente : Entity
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}