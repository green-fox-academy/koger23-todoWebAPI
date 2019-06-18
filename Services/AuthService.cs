using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace myRestAPI.Services
{
    public class AuthService
    {
        public String checkToken(StringValues header)
        {
            if (header.ToString().StartsWith("Basic"))
            {
                var creditentialValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPasswordString = Encoding.UTF8.GetString(Convert.FromBase64String(creditentialValue));
                var usernameAndPassowrd = usernameAndPasswordString.Split(":");
                // here to check in database the username and password
                if (usernameAndPassowrd[0] == "admin" && usernameAndPassowrd[1] == "password")
                {
                    var claimsData = new[] { new Claim(ClaimTypes.Name, usernameAndPassowrd[0]) };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisanotsecuresecuritykey"));
                    var signInCreditentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                        issuer: "example.com",
                        audience: "example.com",
                        expires: DateTime.Now.AddMinutes(1),
                        claims: claimsData,
                        signingCredentials: signInCreditentials
                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return tokenString;
                }
            }
            return "";
        }
    }
}
