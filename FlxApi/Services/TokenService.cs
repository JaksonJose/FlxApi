using Flx.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Flx.Api.Services
{
    /// <summary>
    /// This class is for generate tokens
    /// </summary>
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            
            // Get Criptographed key
            byte[] criptographedKey = Encoding.ASCII.GetBytes(KeyJWT.SecretKey);


            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Name), // User.Identity.Name
                    new Claim(ClaimTypes.Role, user.Role), // User.IsInRole()
                }),
                Expires = DateTime.UtcNow.AddHours(8), //token lifetime
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(criptographedKey), SecurityAlgorithms.HmacSha256Signature),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);          

            return tokenHandler.WriteToken(token);
        }
    }
}
