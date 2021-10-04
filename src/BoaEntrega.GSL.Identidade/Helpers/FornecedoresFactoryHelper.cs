using System.Collections.Generic;

using BookService.Models;

namespace BookService.Helpers
{
    public static class FornecedoresFactoryHelper
    {
        public static IEnumerable<Fornecedor> CreateFornecedores()
        {
            for (int i = 0; i < 50; i++)
            {
                yield return new Fornecedor
                {
                    Codigo = i,
                    Nome = $"Cliente Teste {i}"
                };
            }
        }
    }
}