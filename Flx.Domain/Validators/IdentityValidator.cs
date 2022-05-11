using Flx.Domain.Identity;
using Flx.Domain.Identity.models;
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

            User user = userResponse.ResponseData[0];

            if (!PasswordHash.PasswordHashIsMatch(auth.Password, user.PasswordHash, user.PasswordSalt))
            {
                userResponse.AddErrorMessage("Wrong Password");
            }

            return userResponse;
        }

        /// <summary>
        /// Verify if already exist user name and email
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="userRegister"></param>
        /// <returns></returns>
        public UserInquiryResponse RegisterUserValidation(List<User> userList, Register userRegister)
        {
            UserInquiryResponse userResponse = new();

            foreach (User user in userList)
            {
                if (user.UserName.Equals(userRegister.UserName))
                {
                    userResponse.AddErrorMessage("UserName already exist");
                }

                if (user.Email.Equals(user.Email))
                {
                    userResponse.AddErrorMessage("Email already exist");
                }

                if (userResponse.HasErrorMessages)
                {
                    return userResponse;
                }
            }

            return userResponse;
        }
    }
}