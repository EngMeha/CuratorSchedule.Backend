using EventService.Domain.Entities;
using EventService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Data.EntityConfigurations;

public class EventConfiguration: IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Place).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Address).HasMaxLength(300).IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .HasDefaultValue(EventStatus.Planned);
        
        builder.HasMany(e=> e.CategoryEvents)
            .WithOne(e => e.Event)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Metadata
            .FindNavigation(nameof(Event.CategoryEvents))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}