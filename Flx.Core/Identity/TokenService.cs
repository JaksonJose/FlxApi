using Flx.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Flx.Core.Identity
{
    /// <summary>
    /// This class is for generate tokens
    /// </summary>
    public static class TokenService
    {
        public static string GenerateToken(this User user, KeyJWT jwtKey)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            
            // Get Criptographed key
            byte[] criptographedKey = Encoding.ASCII.GetBytes(jwtKey.SecretKey);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {   
                    new Claim(ClaimTypes.Email, user.Email), // User.Identity.Name
                    //new Claim(ClaimTypes.Role, auth.Role.Name), // User.IsInRole() // TODO: Make the roles
                }),
                Expires = DateTime.UtcNow.AddHours(8), //token lifetime
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(criptographedKey), SecurityAlgorithms.HmacSha256Signature),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);          

            return tokenHandler.WriteToken(token);
        }
    }
}
