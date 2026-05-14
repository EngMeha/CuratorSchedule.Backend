using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GroupService.Infrastructure.Auth;
using GroupService.Infrastructure.Auth.Jwt;
using GroupService.Infrastructure.Data;
using GroupService.Infrastructure.DI.Modules;
using GroupService.Infrastructure.Services;

namespace GroupService.Infrastructure.DI;

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