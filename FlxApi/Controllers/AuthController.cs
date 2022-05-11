using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flx.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IIdentityBac _identity;
        private readonly IUserRepo _userRepo;

        public AuthController(ILogger<AuthController> logger, IIdentityBac identity, IUserRepo userRepo)
        {
            _logger = logger;
            _identity = identity;
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<UserInquiryResponse> SignInAsync([FromBody] SignIn auth)
        {     
            ModelOperationRequest<SignIn> request = new(auth);     

            UserInquiryResponse userResponse = await _userRepo.FetchUserByEmail(request);
            if (userResponse.HasErrorMessages) return userResponse;

            userResponse = _identity.AuthUserBac(auth, userResponse);
            if (userResponse.HasErrorMessages) return userResponse;         

            _logger.LogInformation("User was successfully Authenticated.");

            return userResponse;            
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<UserInquiryResponse> RegisterCredential([FromBody] SignIn auth)
        {
            UserInquiryResponse response = _identity.RegisterCredentialBac(auth);
            if (response.HasErrorMessages) return response;

            ModelOperationRequest<User> request = new(response.ResponseData.FirstOrDefault());

            response = await _userRepo.InsertUserAsync(request);
            if (response.HasErrorMessages) return response;

            return response;
        }      
    }
}
