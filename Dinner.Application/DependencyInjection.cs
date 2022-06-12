using Dinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Dinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        return service;
    }
}
