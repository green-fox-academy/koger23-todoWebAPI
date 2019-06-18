using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace myRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            var claimsData = new[] { new Claim(ClaimTypes.Name, "username") };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisanotsecuresecuritykey"));
            var signInCreditentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer:"example.com",
                audience:"example.com",
                expires:DateTime.Now.AddMinutes(1),
                claims:claimsData,
                signingCredentials:signInCreditentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenString);
        }
    }
}