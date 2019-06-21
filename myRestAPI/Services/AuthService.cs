using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using myRestAPI.Helpers;
using myRestAPI.Models.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace myRestAPI.Services
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private IOptions<AppSettings> _appSettings;

        public AuthService(IUserService userService, IOptions<AppSettings> appSettings)
        {
            this._userService = userService;
            this._appSettings = appSettings;
        }

        public ActionResult<User> checkToken(StringValues header)
        {
            var creditentialValue = header.ToString().Substring("Basic ".Length).Trim();
            if (creditentialValue != null)
            {
                var usernameAndPasswordString = Encoding.UTF8.GetString(Convert.FromBase64String(creditentialValue));
                var usernameAndPassowrd = usernameAndPasswordString.Split(":");
                var user = _userService.Authenticate(usernameAndPassowrd[0], usernameAndPassowrd[1]);
                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.Secret));

                    var claimsData = new Claim[] 
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()), 
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.Role, user.Role)
                    };
                        
                    var signInCreditentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                                                        issuer: "example.com",
                                                        audience: "example.com",
                                                        expires: DateTime.Now.AddMinutes(10),
                                                        claims: claimsData,
                                                        signingCredentials: signInCreditentials
                                                        );
                    user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    user.PasswordHash = null;
                    user.PasswordSalt = null;
                    return user;
                    
                }
            }
            return new NotFoundObjectResult("User does not exists or wrong password");
        }
    }
}
