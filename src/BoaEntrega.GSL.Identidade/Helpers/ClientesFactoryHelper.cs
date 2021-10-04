using System;
using System.Collections.Generic;

using BookService.Models;

namespace BookService.Helpers
{
    public static class ClientesFactoryHelper
    {
        public static IEnumerable<Cliente> CreateClientes()
        {
            for (int i = 0; i < 50; i++)
            {
                yield return new Cliente
                {
                    Codigo = i,
                    Nome = $"Cliente Teste {i}"
                };
            }
        }
    }
}