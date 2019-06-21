using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using myRestAPI.Models.User;

namespace myRestAPI.Services
{
    public interface IAuthService
    {
        ActionResult<User> checkToken(StringValues header);
    }
}
