using Flx.Api.Services;
using Flx.Data.Repository.IRepository;
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
        private readonly IUserRepo _userRepo;

        public LoginController(ILogger<LoginController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] Login login)
        {
            User user = new()
            {
                Id = 1,
                Name = "Batman",
                Role = "Admin",
                Token = "",
            };

            //var response = _userRepo.Get(user.Name, user.Password);

            var token = TokenService.GenerateToken(user);

            user.Token = token;

            return user;
        }
    }
}
