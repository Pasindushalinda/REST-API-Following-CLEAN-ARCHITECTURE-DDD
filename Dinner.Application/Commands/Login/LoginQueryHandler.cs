using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Entities;
using ErrorOr;
using MediatR;
using Dinner.Domain.Common.Errors;
using Dinner.Application.Commands.Common;

namespace Dinner.Application.Commands.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(
        IJwtTokenGenerator tokenGenerator,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {   //1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        //2. Validate the password is correct
        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        //3. Create JWT token
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
