using EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Data.EntityConfigurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        
        builder.HasIndex(x => x.Name).IsUnique();
        
        builder.HasMany(x=>x.CategoryEvents)
            .WithOne(x=>x.Category)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Metadata
            .FindNavigation(nameof(Category.CategoryEvents))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}