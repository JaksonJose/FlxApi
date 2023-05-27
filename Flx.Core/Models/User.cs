using Flx.Core.Identity.Enums;
using System.Text.Json.Serialization;

namespace Flx.Core.Models
{
    public class User : BaseSAModel
    {
        public int Id { get; set; }
        public RoleEnum Role { get; set; } = RoleEnum.None;
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public bool EmailConfirmed { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;

        [JsonIgnore]
        public string PasswordSalt { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
