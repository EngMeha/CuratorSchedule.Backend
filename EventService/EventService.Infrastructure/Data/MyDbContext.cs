using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Data;

public class MyDbContext: DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureAssemblyMarker).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}