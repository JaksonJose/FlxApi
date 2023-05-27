using Flx.Core.Identity.models;
using Flx.Core.Identity.Models;
using Flx.Core.Interfaces.IBAC;
using Flx.Core.Responses;
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
            UserInquiryResponse userResponse = await _identity.AuthUserBacAsync(auth);
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
            UserInquiryResponse response = await _identity.RegisterCredentialBacAsync(userRegister);
            if (response.HasErrorMessages)
            {
                return BadRequest(response);
            }     

            response.AddInfoMessage("User successfully registered", StatusCodes.Status201Created);           

            return Ok(response);
        }      
    }
}