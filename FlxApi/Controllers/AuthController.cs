using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity.models;
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
        public async Task<ActionResult> SignInAsync([FromBody] SignIn auth)
        {     
            ModelOperationRequest<SignIn> request = new(auth);     

            UserInquiryResponse userResponse = await _userRepo.FetchUserByEmail(request);
            if (userResponse.HasExceptionMessages) return BadRequest(userResponse);                 
               
            userResponse = _identity.AuthUserBac(auth, userResponse);
            if (userResponse.HasErrorMessages) return BadRequest(userResponse);     

            _logger.LogInformation("User was successfully Authenticated.");

            return Ok(userResponse);            
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterCredential([FromBody] Register userRegister)
        {
            List<User> userList = await _userRepo.FetchAllUsers();         

            var response = _identity.RegisterCredentialBac(userRegister, userList);
            if (response.HasErrorMessages) return BadRequest(response);

            ModelOperationRequest<User> request = new(response.ResponseData.First());

            response = await _userRepo.InsertUserAsync(request);
            if (response.HasExceptionMessages) return BadRequest(response);           

            response.AddInfoMessage("User successfully registered", StatusCodes.Status201Created);           

            return Ok(response);
        }      
    }
}