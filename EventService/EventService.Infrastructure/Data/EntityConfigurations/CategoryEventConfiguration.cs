using EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Data.EntityConfigurations;

public class CategoryEventConfiguration: IEntityTypeConfiguration<CategoryEvent>
{
    public void Configure(EntityTypeBuilder<CategoryEvent> builder)
    {
        builder.HasOne(ce => ce.Category)
            .WithMany(ce => ce.CategoryEvents)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(ce => ce.Event)
            .WithMany(ce => ce.CategoryEvents)
            .OnDelete(DeleteBehavior.Cascade);
    }
}