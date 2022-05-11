using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
using Flx.Domain.Identity.Enums;
using Flx.Domain.Identity.models;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Domain.Validators.IValidators;

namespace Flx.Domain.BAC
{
    public class IdentityBac : IIdentityBac
    {
        private readonly IIdentityValidator _identity;
        public IdentityBac(IIdentityValidator identity)
        {
            _identity = identity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="userResponse"></param>
        /// <returns></returns>
        public UserInquiryResponse AuthUserBac(SignIn auth, UserInquiryResponse userResponse)
        {       
            userResponse = _identity.UserAuthenticationValidation(auth, userResponse);
            if (userResponse.HasErrorMessages)
            {
                return userResponse;
            }

            string token = TokenService.GenerateToken(auth);
            userResponse.Token = token;


            return userResponse;
        }

        /// <summary>
        /// Register user credentials
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public UserInquiryResponse RegisterCredentialBac(Register userRegister, List<User> userList)
        {
            // Verify if already there is a user and email registered
            UserInquiryResponse userResponse = _identity.RegisterUserValidation(userList, userRegister);
            if (userResponse.HasErrorMessages) return userResponse;

            User user = PasswordHash.CreatePasswordHash(userRegister.Password);

            user.UserName = userRegister.UserName;
            user.Email = userRegister.Email;
            user.EmailConfirmed = userRegister.EmailConfirmed;
            user.FirstName = userRegister.FirstName;
            user.LastName = userRegister.LastName;

            userResponse.ResponseData.Add(user);

            return userResponse;
        }
    }
}
