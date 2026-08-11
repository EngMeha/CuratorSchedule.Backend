using GroupService.Domain.Entities.ValueObjects;
using GroupService.Domain.Exceptions;

namespace GroupService.Domain.Entities;

public class GroupEvent
{
    public Guid Id { get; private set; }
    public Guid GroupId { get; private set; }
    public Group Group { get; private set; } = null!;
    public Guid EventProjectionId { get; private set; }
    public EventProjection EventProjection { get; private set; } = null!;
    public int PlannedCount { get; private set; }    
    public int? ActualCount { get; private set; }    
    public GroupEventStatus Status { get; private set; }
    
    private GroupEvent(){}

    public GroupEvent(Guid groupId, Guid eventProjectionId, int plannedCount)
    {
        if (plannedCount < 0)
            throw new DomainException("plannedCount cannot be negative");
        
        Id = Guid.NewGuid();
        GroupId = groupId;
        EventProjectionId = eventProjectionId;
        PlannedCount = plannedCount;
        Status = GroupEventStatus.Planned;
    }
    
    public void Miss()
    {
        EnsurePlanned();
        Status = GroupEventStatus.Missed;
    }

    public void Complete(int actualCount)
    {
        if (actualCount < 0)
            throw new DomainException("actualCount cannot be negative");
        
        EnsurePlanned();
        
        ActualCount = actualCount;
        Status = GroupEventStatus.Completed;
    }

    public void Canceled()
    {
        EnsurePlanned();
        Status = GroupEventStatus.Canceled;
    }
    
    private void EnsurePlanned()
    {
        if (Status != GroupEventStatus.Planned )
            throw new DomainException($"Cannot change status: event is already {Status}");
    }
}