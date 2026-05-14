using Microsoft.Extensions.DependencyInjection;
using EventService.Application.Interfaces;

namespace EventService.Infrastructure.Auth;

public static class AuthServiceCollectionExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}