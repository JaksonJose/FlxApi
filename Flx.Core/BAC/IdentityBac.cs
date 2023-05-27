using Flx.Core.Identity;
using Flx.Core.Identity.Enums;
using Flx.Core.Identity.models;
using Flx.Core.Identity.Models;
using Flx.Core.Interfaces.IBAC;
using Flx.Core.Interfaces.IRepository;
using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Core.Validators.IValidators;
using Flx.Shared.Requests;
using Microsoft.Extensions.Options;

namespace Flx.Core.BAC
{
    public class IdentityBac : IIdentityBac
    {
        private readonly IIdentityValidator _identity;
        private readonly IUserRepo _userRepo;
        private readonly KeyJWT _keyJWT;

        public IdentityBac(IUserRepo userRepo, IIdentityValidator identity, IOptions<KeyJWT> keyJWT)
        {
            _userRepo = userRepo;
            _identity = identity;
            _keyJWT = keyJWT.Value;
        }

        /// <summary>
        /// Fetch user and make the login
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="userResponse"></param>
        /// <returns></returns>
        public async Task<UserInquiryResponse> AuthUserBac(SignIn auth)
        {
            User user = new()
            {
                Email = auth.Email,                
            };

            ModelOperationRequest<User> request = new(user);

            UserInquiryResponse userResponse = await _userRepo.FetchUserByEmail(request);

            userResponse = _identity.UserNotExists(userResponse);
            if (userResponse.HasValidationMessages)
            {
                userResponse.ResponseData = new();
                return userResponse;
            }

            userResponse = _identity.UserAuthenticationValidation(auth, userResponse);
            if (userResponse.HasValidationMessages)
            {
                userResponse.ResponseData = new();
                return userResponse;
            }

            string token = user.GenerateToken(_keyJWT);
            userResponse.Token = token;       

            return userResponse;
        }

        /// <summary>
        /// Registers user credentials
        /// </summary>
        /// <param name="auth">Register object</param>
        /// <returns>User response</returns>
        public async Task<UserInquiryResponse> RegisterCredentialBac(Register userRegister)
        {
            User user = new()
            {
                Email = userRegister.Email,
            };

            ModelOperationRequest<User> request = new(user);

            UserInquiryResponse userResponse = await _userRepo.FetchUserByEmail(request); 
            userResponse = _identity.UserExists(userResponse);
            if (userResponse.HasValidationMessages)
            {
                return userResponse;
            }

            // Verify if already there is a user and email registered
            userResponse = _identity.RegisterUserValidation(userRegister, userResponse);
            if (userResponse.HasValidationMessages)
            {
                return userResponse;
            }

            user = PasswordHash.CreatePasswordHash(userRegister.Password);

            user.UserName = userRegister.UserName;
            user.Email = userRegister.Email;
            user.EmailConfirmed = true; // TODO: Should be implamented later (send an email for user confirmation)
            user.FirstName = userRegister.FirstName;
            user.LastName = userRegister.LastName;
            user.Role = RoleEnum.Student; // Student is the default role.

            userResponse.ResponseData.Add(user);

            request = new(userResponse.ResponseData.First());

            userResponse = await _userRepo.InsertUserAsync(request);
            if (userResponse.HasExceptionMessages)
            {
                return userResponse;
            }

            userResponse = await _userRepo.FetchUserByEmail(request);
            userResponse.Token = user.GenerateToken(_keyJWT);

            return userResponse;
        }
    }
}
