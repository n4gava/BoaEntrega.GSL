using System.ComponentModel.DataAnnotations;

namespace BoaEntrega.GSL.Cadastros.Domain
{
    public class Endereco
    {
        [Required]
        public string CEP { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string UF { get; set; }

        public string Complemento { get; set; }

    }
}
