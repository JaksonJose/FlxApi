using Flx.Domain.Models;
using Flx.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Flx.Api.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<UserInquiryResponse> Login([FromBody] ApplicationUser loginRequest)
        {
            UserInquiryResponse response = new();
            
            // later refactorate the the validation logic
            try
            {
                if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Login) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    response.AddExceptionMessage("Invalid entry parameters", StatusCodes.Status400BadRequest);

                    return response;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to loggin {ex.Message}: {loginRequest}");

                response.AddExceptionMessage("Error while trying to loggin", StatusCodes.Status500InternalServerError);

                return response;
            }

            return response;
        }
    }
}
