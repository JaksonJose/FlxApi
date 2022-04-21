using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Domain.Validators.IValidators;
using System.Text;

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
        /// Sign In
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public UserInquiryResponse AuthLoginBac(Auth auth)
        {
            UserInquiryResponse response =  _identity.AuthCredentialsValidation(auth);
            
            if (response.HasErrorMessages)
            {
                return response;
            }

            string token = TokenService.GenerateToken(auth);

            response.Token = token;

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="userResponse"></param>
        /// <returns></returns>
        public UserInquiryResponse AuthUserBac(Auth auth, UserInquiryResponse userResponse)
        {     

            userResponse = _identity.UserAuthenticationValidation(auth, userResponse);

            return userResponse;
        }

        /// <summary>
        /// Register user credentials
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public UserInquiryResponse RegisterCredentialBac(Auth auth)
        {
            UserInquiryResponse response = _identity.AuthCredentialsValidation(auth);
            if (response.HasErrorMessages) return response;

            User user = UserBuilder(auth);   

            response.ResponseData.Add(user);

            return response;
        }
  
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
