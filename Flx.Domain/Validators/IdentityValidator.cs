using Flx.Domain.Identity;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Domain.Validators.IValidators;
using System.Text.RegularExpressions;

namespace Flx.Domain.Validators
{
    public class IdentityValidator : IIdentityValidator
    {

        /// <summary>
        /// Validadate the credentials (email and password)
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public bool AuthCredentialsValidation(Auth auth)
        {
            // TODO: Improve this later            
            Regex emailForm = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if(string.IsNullOrEmpty(auth.Email) || string.IsNullOrWhiteSpace(auth.Email) || !emailForm.Match(auth.Email).Success)
            {
                return false;
            }            
            
            // TODO: Improve this later            
            if(string.IsNullOrEmpty(auth.Password) || string.IsNullOrWhiteSpace(auth.Password) || auth.Password.Length < 4 && 
                Regex.IsMatch(auth.Password, "[a-ZA-Z0-9]+", RegexOptions.IgnoreCase))
            {
                return false;
            }            

            return true;
        }
        
        /// <summary>
        /// Varify if the password is matched
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserInquiryResponse UserAuthenticationValidation(Auth auth, UserInquiryResponse userResponse)
        {
            if (!userResponse.ResponseData.Any())
            {
                userResponse.AddErrorMessage("user can't be null");
                return userResponse;
            }

            User user = userResponse.ResponseData.FirstOrDefault();

            if (!PasswordHash.PasswordHashIsMatch(auth.Password, user.PasswordHash, user.PasswordSalt))
            {
                userResponse.AddErrorMessage("Wrong Password");
            }

            return userResponse;
        }
    }
}