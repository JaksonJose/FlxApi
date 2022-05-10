using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
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
        public UserInquiryResponse AuthUserBac(Auth auth, UserInquiryResponse userResponse)
        {
            bool isValidated = _identity.AuthCredentialsValidation(auth);
            if (!isValidated)
            {
                return userResponse;
            }

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
        public UserInquiryResponse RegisterCredentialBac(Auth auth)
        {
            UserInquiryResponse userResponse = new();

            bool isValidated = _identity.AuthCredentialsValidation(auth);
            if (!isValidated)
            {
                return userResponse;
            }

            User user = UserBuilder(auth);

            userResponse.ResponseData.Add(user);

            return userResponse;
        }
  
        /// <summary>
        /// Build the user object
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        private static User UserBuilder(Auth auth)
        {
            User user = PasswordHash.CreatePasswordHash(auth.Password);

            user.Email = auth.Email;

            //TODO Resolve this
            //Mock User
            user.UserName = "Spiderman";
            user.EmailConfirmed = true ;
            user.FirstName = "Venon";
            user.LastName = "No Way Home";

            return user;
        }
    }
}
