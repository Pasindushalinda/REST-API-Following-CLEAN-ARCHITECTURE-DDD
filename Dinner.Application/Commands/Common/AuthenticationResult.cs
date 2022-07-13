using Dinner.Domain.Entities;

namespace Dinner.Application.Commands.Common;
public record AuthenticationResult(
User User,
string Token
);
