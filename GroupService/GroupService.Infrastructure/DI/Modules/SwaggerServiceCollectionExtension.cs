using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace GroupService.Infrastructure.DI.Modules;

public static class SwaggerServiceCollectionExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "GroupService", Version = "v1" });
        });

        return services;
    }
}