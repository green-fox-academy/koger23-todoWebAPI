using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using myRestAPI.Models.User;
using System;

namespace myRestAPI.Services
{
    public interface IAuthService
    {
        ActionResult<string> checkToken(StringValues header);
    }
}
