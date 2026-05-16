using GroupService.Domain.Entities.ValueObjects;

namespace GroupService.Domain.Entities;

public class GroupEvent
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public Guid EventProjectionId { get; set; }
    public EventProjection EventProjection { get; set; }
    public int PlannedCount { get; set; }    
    public int? ActualCount { get; set; }    
    public EventStatus Status { get; set; }
}