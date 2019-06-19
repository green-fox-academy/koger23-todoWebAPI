using Microsoft.AspNetCore.Mvc;
using myRestAPI.Services;

namespace myRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("token")]
        public IActionResult Token()
        {
            string result = authService.checkToken(Request.Headers["Authorization"]);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}