using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupService.Infrastructure.Data.EntityConfigurations;

public class GroupConfiguration: IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasIndex(g => g.Name).IsUnique();
        
        builder.Property(g => g.Name).HasMaxLength(100).IsRequired();
        
        builder.HasMany(g => g.GroupEvents)
            .WithOne(g => g.Group)
            .HasForeignKey(g => g.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Metadata
            .FindNavigation(nameof(Group.GroupEvents))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}