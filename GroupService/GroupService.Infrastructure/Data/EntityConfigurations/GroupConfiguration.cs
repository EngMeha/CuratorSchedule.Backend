using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupService.Infrastructure.Data.EntityConfigurations;

public class GroupConfiguration: IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasIndex(g => g.Name).IsUnique();
    }
}