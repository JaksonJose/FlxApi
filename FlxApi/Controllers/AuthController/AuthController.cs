using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
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

        public AuthController(ILogger<AuthController> logger, IIdentityBac identity)
        {
            _logger = logger;
            _identity = identity;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserInquiryResponse> AuthenticateAsync([FromBody] Auth auth)
        {
            UserInquiryResponse response = new();

            User user = new()
            {
                Id = 1,
                Name = "Batman",
                Role = "Admin",
                Token = "",
            };

            try
            {
                response = _identity.AuthBac(auth);
            }
            catch (Exception ex)
            {
                return response;
            }

            var token = TokenService.GenerateToken(auth);

            user.Token = token;

            return response;
        }
    }
}
