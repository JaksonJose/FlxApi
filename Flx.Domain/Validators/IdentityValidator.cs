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
        /// Varify if the password is matched
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserInquiryResponse UserAuthenticationValidation(SignIn auth, UserInquiryResponse userResponse)
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