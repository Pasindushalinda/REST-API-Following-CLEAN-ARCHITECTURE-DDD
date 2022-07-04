using Dinner.Application.Common.Errors;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Entities;

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
    public AuthenticationResult Login(string email, string password)
    {
        //1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User with given email does not exists.");

        //2. Validate the password is correct
        if (user.Password != password)
            throw new Exception("Invalid password");

        //3. Create JWT token
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Resister(string firstName, string lastName, string email, string password)
    {
        //1.check if user already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
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
