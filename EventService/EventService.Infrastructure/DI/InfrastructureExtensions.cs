using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventService.Infrastructure.Auth;
using EventService.Infrastructure.Auth.Jwt;
using EventService.Infrastructure.Data;
using EventService.Infrastructure.DI.Modules;
using EventService.Infrastructure.Services;

namespace EventService.Infrastructure.DI;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddData(configuration);        
        services.AddAuth();                     
        services.AddJwt(configuration);        
        services.AddCorsPolicies(configuration);             
        services.AddSwagger();                  
        services.AddExceptionHandler<GlobalExceptionHandler>(); 
        services.AddProblemDetails();
        return services;
    }
}