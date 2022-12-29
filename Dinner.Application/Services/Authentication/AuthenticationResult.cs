using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dinner.Application.Services.Authentication
{
    public record AuthenticationResult(
    Guid id,
    string FirstName,
    string LastName,
    string Email,
    string Token
    );
}