using Flx.Domain.Identity;
using Flx.Domain.Identity.models;
using Flx.Domain.Identity.Models;
using Flx.Domain.Interfaces.IBAC;
using Flx.Domain.Interfaces.IRepository;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Domain.Validators.IValidators;
using Flx.Shared.Requests;
using Microsoft.Extensions.Options;

namespace Flx.Domain.BAC
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
            UserInquiryResponse userResponse = await _userRepo.FetchUserByEmail(auth);

            userResponse = _identity.UserAuthenticationValidation(auth, userResponse);
            if (userResponse.HasErrorMessages)
            {
                userResponse.ResponseData = new();
                return userResponse;
            }           

            string token = auth.GenerateToken(_keyJWT);
            userResponse.Token = token;           

            return userResponse;
        }

        /// <summary>
        /// Register user credentials
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public async Task<UserInquiryResponse> RegisterCredentialBac(Register userRegister)
        {
            List<User> userList = await _userRepo.FetchAllUsers();

            // Verify if already there is a user and email registered
            UserInquiryResponse userResponse = _identity.RegisterUserValidation(userList, userRegister);
            if (userResponse.HasErrorMessages)
            {
                return userResponse;
            }

            User user = PasswordHash.CreatePasswordHash(userRegister.Password);

            user.UserName = userRegister.UserName;
            user.Email = userRegister.Email;
            user.EmailConfirmed = userRegister.EmailConfirmed;
            user.FirstName = userRegister.FirstName;
            user.LastName = userRegister.LastName;

            userResponse.ResponseData.Add(user);

            ModelOperationRequest<User> request = new(userResponse.ResponseData.First());

            UserInquiryResponse response = await _userRepo.InsertUserAsync(request);

            return response;
        }
    }
}
