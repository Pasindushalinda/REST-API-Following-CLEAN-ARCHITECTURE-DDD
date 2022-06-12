namespace Dinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Resister(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}
