using Flx.Core.Identity.Enums;
using Flx.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Flx.Core.Identity.Models
{
    public class SignIn
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength = 6, ErrorMessage = "Password must have at least 6 character")]
        public string Password { get; set; } = string.Empty;
    }
}