using Dinner.Application.Common.Errors;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Common.Errors;
using Dinner.Domain.Entities;
using ErrorOr;

namespace Dinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(
        IJwtTokenGenerator tokenGenerator,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        //2. Validate the password is correct
        if (user.Password != password)
            return Errors.Authentication.InvalidCredentials;

        //3. Create JWT token
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationResult> Resister(string firstName, string lastName, string email, string password)
    {
        //1.check if user already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //2.create user(Generate unique id)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //3.create jwt token
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
