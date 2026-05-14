using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace GroupService.Infrastructure.DI;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });
        return services;
    }
}