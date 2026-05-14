using Microsoft.Extensions.DependencyInjection;
using GroupService.Application.Interfaces;

namespace GroupService.Infrastructure.Auth;

public static class AuthServiceCollectionExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}