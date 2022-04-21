using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
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
        public async Task<UserInquiryResponse> AuthenticateAsync([FromBody] Auth auth)
        {
            UserInquiryResponse response = _identity.AuthLoginBac(auth);
            if (response.HasErrorMessages) return response;
     
            ModelOperationRequest<Auth> request = new(auth);

            response = await _userRepo.FetchUserByEmail(request, response);
            if (response.HasErrorMessages) return response;
            
            response = _identity.AuthUserBac(auth, response);
            if (response.HasErrorMessages) return response;         

            _logger.LogInformation("User was successfully Authenticated.");

            return response;            
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<UserInquiryResponse> RegisterCredential(Auth auth)
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
