using GroupService.Domain.Entities.ValueObjects;

namespace GroupService.Domain.Entities;

public class GroupEvent
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public Guid EventProjectionId { get; set; }
    public EventProjection EventProjection { get; set; } = null!;
    public uint PlannedCount { get; set; }    
    public uint? ActualCount { get; set; }    
    public EventStatus Status { get; set; }
}