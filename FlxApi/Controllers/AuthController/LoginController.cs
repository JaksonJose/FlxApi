using Flx.Api.Services;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flx.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public User UserLogin([FromBody] Login login)
        {
            User user = new()
            {
                Id = 1,
                Name = "Batman",
                Role = "Admin",
                Token = "",
            };

            var token = TokenService.GenerateToken(login);

            user.Token = token;

            return user;
        }
    }
}
