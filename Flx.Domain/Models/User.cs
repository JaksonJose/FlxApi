using Flx.Domain.Identity.Enums;
using System.ComponentModel.DataAnnotations;

namespace Flx.Domain.Models
{
    public class User : BaseSAModel
    {
        public int Id { get; set; }
        public RoleEnum Role { get; set; } = RoleEnum.None;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
