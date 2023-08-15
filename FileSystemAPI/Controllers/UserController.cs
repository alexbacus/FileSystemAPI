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
        public ActionResult<string> Login(LoginRequest request)
        {
            var user = userManager.ReadUser(request.Username);
            UserSession session = userSessionManager.GetActiveSession();

            session.Login(user);

            return this.Ok("Root: \"/\"");
        }
    }
}
