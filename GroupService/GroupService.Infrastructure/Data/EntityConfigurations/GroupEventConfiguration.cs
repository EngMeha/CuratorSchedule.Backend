using GroupService.Domain.Entities;
using GroupService.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupService.Infrastructure.Data.EntityConfigurations;

public class GroupEventConfiguration: IEntityTypeConfiguration<GroupEvent>
{
    public void Configure(EntityTypeBuilder<GroupEvent> builder)
    {
        builder.Property(ge => ge.Status)
            .HasConversion<string>()
            .HasDefaultValue(GroupEventStatus.Planned);

        builder.HasIndex(ge => new { ge.EventProjectionId, ge.GroupId }).IsUnique();
        
        builder.HasOne(ge => ge.Group)
            .WithMany(g => g.GroupEvents)
            .HasForeignKey(ge => ge.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ge => ge.EventProjection)
            .WithMany(ep => ep.GroupEvents)
            .HasForeignKey(ge => ge.EventProjectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}