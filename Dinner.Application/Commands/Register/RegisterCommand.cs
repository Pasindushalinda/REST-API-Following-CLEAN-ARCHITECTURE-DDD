using Dinner.Application.Commands.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Commands.Register;

public record RegisterCommand(
string FirstName,
string LastName,
string Email,
string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
