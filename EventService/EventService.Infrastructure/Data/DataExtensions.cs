using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventService.Application.Interfaces;
using EventService.Application.Interfaces.Ports;
using EventService.Application.Interfaces.QueryObjects;

namespace EventService.Infrastructure.Data;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<EventDbContext>(options =>
        {
            options.UseNpgsql(connectionString, x 
                => x.MigrationsAssembly("EventService.Infrastructure"));
        });

        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        
        services.Scan(scan => scan
            .FromAssemblyOf<InfrastructureAssemblyMarker>()
            .AddClasses(classes => classes.AssignableTo<IPortMarker>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        services.Scan(scan => scan
            .FromAssemblyOf<InfrastructureAssemblyMarker>()
            .AddClasses(classes => classes.AssignableTo<IQueryMarker>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        return services;
    }
}