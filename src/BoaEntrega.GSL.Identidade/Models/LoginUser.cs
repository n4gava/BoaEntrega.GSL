using System.ComponentModel.DataAnnotations;

namespace BoaEntrega.GSL.Identidade.Models
{
    public class LoginUser
    {
        /// <summary>
        /// E-mail
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
