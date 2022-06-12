using Dinner.Application.Common.Interfaces.Authentication;

namespace Dinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    public AuthenticationService(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;

    }
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }

    public AuthenticationResult Resister(string firstName, string lastName, string email, string password)
    {
        //check if user already exist

        //create user(Generate unique id)

        //create jwt token

        Guid userId=Guid.NewGuid();

        var token=_tokenGenerator.GenerateToken(userId,firstName,lastName);

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }
}
