using System.ComponentModel.DataAnnotations;

namespace BoaEntrega.GSL.Identidade.Models
{
    public class LoginUser
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
