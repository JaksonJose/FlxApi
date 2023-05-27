using Flx.Core.Identity;
using Flx.Core.Identity.models;
using Flx.Core.Identity.Models;
using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Core.Validators.IValidators;
using Microsoft.AspNetCore.Http;

namespace Flx.Core.Validators
{
    public class IdentityValidator : IIdentityValidator
    { 
        /// <summary>
        /// Verifies if user do not exist
        /// </summary>
        /// <param name="userResponse"></param>
        /// <returns></returns>
        public UserInquiryResponse UserNotExists(UserInquiryResponse userResponse)
        {
            if (!userResponse.ResponseData.Any())
            {
                userResponse.AddValidationMessage("User do not exist!", StatusCodes.Status404NotFound);
                return userResponse;
            }

            return userResponse;
        }

        public UserInquiryResponse UserExists(UserInquiryResponse userResponse)
        {
            if (userResponse.ResponseData.Any())
            {
                userResponse.AddValidationMessage("User already exist, try to login!", StatusCodes.Status409Conflict);
                return userResponse;
            }

            return userResponse;
        }

        /// <summary>
        /// Varifies if the password is matched
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserInquiryResponse UserAuthenticationValidation(SignIn auth, UserInquiryResponse userResponse)
        {
            User? user = userResponse.ResponseData.FirstOrDefault();

            if (user == null || !PasswordHash.PasswordHashIsMatch(auth.Password, user.PasswordHash, user.PasswordSalt))
            {
                userResponse.AddValidationMessage("User or Password not match", StatusCodes.Status401Unauthorized);
                return userResponse;
            }

            userResponse.AddInfoMessage("User authenticated", StatusCodes.Status200OK);

            return userResponse;
        }

        /// <summary>
        /// Verifies if already exist user name and email
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="userRegister"></param>
        /// <returns></returns>
        public UserInquiryResponse RegisterUserValidation(Register userRegister, UserInquiryResponse userResponse)
        {
            User? user = userResponse.ResponseData.FirstOrDefault();

            if (user != null && user.UserName.Equals(userRegister.UserName))
            {
                userResponse.AddValidationMessage("UserName already exist", StatusCodes.Status409Conflict);
            }

            if (user != null && user.Email.Equals(userRegister.Email))
            {
                userResponse.AddValidationMessage("Email already exist", StatusCodes.Status409Conflict);
            }

            if (user != null && userResponse.HasErrorMessages)
            {
                return userResponse;
            }

            return userResponse;
        }
    }
}