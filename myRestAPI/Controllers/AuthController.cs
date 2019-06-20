using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Services;

namespace myRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public ActionResult<string> Token()
        {
            return authService.checkToken(Request.Headers["Authorization"]);
        }
    }
}