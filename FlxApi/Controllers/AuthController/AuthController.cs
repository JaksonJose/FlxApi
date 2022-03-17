using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
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
        private readonly ILogger<AuthController> _logger;
        private readonly IIdentityBac _identity;
        private readonly IUserRepo _userRepo;

        public AuthController(ILogger<AuthController> logger, IIdentityBac identity, IUserRepo userRepo)
        {
            _logger = logger;
            _identity = identity;
            _userRepo = userRepo;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserInquiryResponse> AuthenticateAsync([FromBody] Auth auth)
        {
            UserInquiryResponse response = _identity.AuthBac(auth);
            if (response.HasErrorMessages)
            {
                return response;
            }

            User user = response.ResponseData.FirstOrDefault();

            try
            {
                ModelOperationRequest<User> request = new(user);

                response = await _userRepo.InsertUserAsync(request);        

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to execute AuthenticateAsync controller: {ex}");
                response.AddExceptionMessage("Error while trying to register the user", StatusCodes.Status500InternalServerError);
                return response;
            }
        }
    }
}
