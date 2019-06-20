using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    interface IAuthService
    {
        String checkToken(StringValues header);
        bool checkUserNameAndPassword(String[] usernameAndPassowrd);
    }
}
