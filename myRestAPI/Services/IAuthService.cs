using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace myRestAPI.Services
{
    public interface IAuthService
    {
        ActionResult<string> checkToken(StringValues header);
    }
}
