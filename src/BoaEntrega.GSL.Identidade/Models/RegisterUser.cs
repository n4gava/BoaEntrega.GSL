using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoaEntrega.GSL.Identidade.Models
{
    public class RegisterUser
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

        /// <summary>
        /// Confirmação da senha
        /// </summary>
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Roles que serão vinculadas ao usuário
        /// </summary>
        public IEnumerable<string> Roles { get; set; }
    }
}
