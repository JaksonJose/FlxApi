using Flx.Domain.Identity.Enums;
using System.ComponentModel.DataAnnotations;

namespace Flx.Domain.Models
{
    public class User : BaseSAModel
    {
        public int Id { get; set; }
        public RoleEnum Role { get; set; } = RoleEnum.None;
        public string Email { get; set; } = String.Empty;
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; } = String.Empty;
        public string PasswordSalt { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
    }
}
