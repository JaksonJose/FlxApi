using Flx.Domain.Identity.Enums;
using Flx.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Flx.Domain.Identity.models
{
    public class Register : BaseSAModel
    {
        [Required]
        public string UserName { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public bool EmailConfirmed { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must have at least 6 character")]
        public string Password { get; set; } = String.Empty;

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        public RoleEnum Role { get; set; } = RoleEnum.Student;
    }
}
