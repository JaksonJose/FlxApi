using Flx.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace Flx.Domain.Identity
{
    public class PasswordHash
    {
        /// <summary>
        /// Create a password Hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="passwordHash"></param>
        public static User CreatePasswordHash(string password)
        {
            User user = new();

            using (HMACSHA512 hmac = new())
            {
                byte[] passwordSalt = hmac.Key;
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                user.PasswordSalt = Convert.ToBase64String(passwordSalt);
                user.PasswordHash = Convert.ToBase64String(passwordHash);

                return user;
            }
        }

        /// <summary>
        /// Verify if password match
        /// passwordSalt is a kind of key to make the hash verification
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        public static bool PasswordHashIsMatch(string password, string passwordHash, string passwordSalt)
        {
            //Convert to byte[]
            byte[] currentPassword = Encoding.UTF8.GetBytes(password);
            byte[] pswHash = Convert.FromBase64String(passwordHash);
            byte[] pswSalt = Convert.FromBase64String(passwordSalt);

            using (HMACSHA512 hmac = new(pswSalt))
            {
                byte[] computeHash = hmac.ComputeHash(currentPassword);

                return computeHash.SequenceEqual(pswHash);
            }
        }
    }
}
