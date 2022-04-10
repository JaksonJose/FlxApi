
using System.ComponentModel.DataAnnotations;

namespace Flx.Domain.Identity.Models
{
    public class Auth
    {
        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }
}
