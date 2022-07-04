using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Application.Common.Interfaces.Services;
using Dinner.Infrastructure.Authentication;
using Dinner.Infrastructure.Persistence;
using Dinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service, ConfigurationManager configuration)
    {
        service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        service.AddScoped<IUserRepository, UserRepository>();
        return service;
    }
}
