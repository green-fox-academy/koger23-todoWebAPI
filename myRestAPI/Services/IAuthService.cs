using Microsoft.Extensions.Primitives;
using System;

namespace myRestAPI.Services
{
    interface IAuthService
    {
        string checkToken(StringValues header);
        bool checkUserNameAndPassword(String[] usernameAndPassowrd);
    }
}
