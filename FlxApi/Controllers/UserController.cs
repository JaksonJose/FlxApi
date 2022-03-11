using Flx.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flx.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public User FetchUser()
        {
            User user = new()
            {
                Id = 1,
                Name = "Batman",
                Role = "Admin",
                Token = "",
            };


            try
            {
               return user;
            }
            catch (Exception ex)
            {
                return user;
            }
        }
    }
}
