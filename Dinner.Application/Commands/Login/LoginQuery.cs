using Dinner.Application.Commands.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Commands.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
