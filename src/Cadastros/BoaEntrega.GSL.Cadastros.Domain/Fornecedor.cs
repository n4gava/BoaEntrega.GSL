using BoaEntrega.GSL.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace BoaEntrega.GSL.Cadastros.Domain
{
    public class Fornecedor : Entity, IAggregateRoot
    {
        protected Fornecedor()
        {

        }

        public Fornecedor(string descricao, Endereco endereco)
        {
            Descricao = descricao;
            Endereco = endereco;
        }

        public int Codigo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public Endereco Endereco { get; set; }

        public string Observacao { get; set; }

        public void AlterarDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            this.Endereco = endereco;
        }

        public void AdicionarObservacao(string observacao)
        {
            this.Observacao = observacao;
        }
    }
}
