using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data;

public class GroupContext: DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupEvent> GroupEvents { get; set; }
    public DbSet<EventProjection> EventProjections { get; set; }
    
    public GroupContext(DbContextOptions<GroupContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureAssemblyMarker).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}