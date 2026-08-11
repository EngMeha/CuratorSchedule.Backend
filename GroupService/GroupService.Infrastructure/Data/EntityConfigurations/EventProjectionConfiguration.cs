using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupService.Infrastructure.Data.EntityConfigurations;

public class EventProjectionConfiguration: IEntityTypeConfiguration<EventProjection>
{
    public void Configure(EntityTypeBuilder<EventProjection> builder)
    {
        builder.HasIndex(ep => ep.EventId).IsUnique();

        builder.Property(e => e.Status)
            .HasConversion<string>();
        
        builder.HasMany(e => e.GroupEvents)
            .WithOne(g => g.EventProjection)
            .HasForeignKey(g => g.EventProjectionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Metadata
            .FindNavigation(nameof(EventProjection.GroupEvents))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}