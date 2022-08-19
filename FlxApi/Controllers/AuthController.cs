using Flx.Domain.Identity.models;
using Flx.Domain.Identity.Models;
using Flx.Domain.Interfaces.IBAC;
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

        public AuthController(ILogger<AuthController> logger, IIdentityBac identity)
        {
            _logger = logger;
            _identity = identity;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> SignInAsync([FromBody] SignIn auth)
        { 

            UserInquiryResponse userResponse = await _identity.AuthUserBac(auth);
            if (userResponse.HasExceptionMessages)
            {
                return BadRequest(userResponse);
            }
                   

            _logger.LogInformation("User was successfully Authenticated.");

            return Ok(userResponse);            
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterCredential([FromBody] Register userRegister)
        {
            UserInquiryResponse response = await _identity.RegisterCredentialBac(userRegister);
            if (response.HasErrorMessages)
            {
                return BadRequest(response);
            }     

            response.AddInfoMessage("User successfully registered", StatusCodes.Status201Created);           

            return Ok(response);
        }      
    }
}