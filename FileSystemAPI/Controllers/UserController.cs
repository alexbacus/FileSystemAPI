using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager userManager;
        private IUserSessionManager userSessionManager;

        public UserController(IUserManager userManager, IUserSessionManager userSessionManager)
        {
            this.userSessionManager = userSessionManager;
            this.userManager = userManager;
        }

        [HttpPost("login")]
        public ActionResult<int> Login(LoginRequest request)
        {
            var userId = userSessionManager.Login(request.Username, request.Password);
            if (userId == 0)
            {
                return this.Unauthorized("Login failed.");
            }

            return this.Ok(userId);
        }
    }
}
