using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoaEntrega.GSL.Identidade.Models
{
    public class RegisterUser
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
