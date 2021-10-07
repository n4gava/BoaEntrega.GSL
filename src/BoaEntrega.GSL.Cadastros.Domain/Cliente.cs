using BoaEntrega.GSL.Core.DomainObjects;

namespace BoaEntrega.GSL.Cadastros.Domain
{
    public class Cliente : Entity, IAggregateRoot
    {
        protected Cliente()
        {

        }

        public Cliente(string descricao, Endereco endereco)
        {
            Descricao = descricao;
            Endereco = endereco;
        }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

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