using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface IAuthService
    {
        Boolean IsUserAuthorizedAsync(String token);
    }
}
