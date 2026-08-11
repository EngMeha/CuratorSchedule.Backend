using GroupService.Domain.Entities.ValueObjects;
using GroupService.Domain.Exceptions;

namespace GroupService.Domain.Entities;

public class EventProjection
{
    private readonly List<GroupEvent> _groupEvents = [];
    public Guid Id { get; private set; }
    public Guid EventId { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public EventStatus Status { get; private set; }
    public IReadOnlyCollection<GroupEvent> GroupEvents =>  _groupEvents.AsReadOnly();
    
    private EventProjection(){}

    public EventProjection(Guid eventId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime)
    {
        if (startDate > endDate)
            throw new DomainException("Start date cannot be greater than end date");
        
        if (startDate == endDate && startTime >= endTime)
            throw new DomainException("Start time cannot be greater than end time");
        
        Id = Guid.NewGuid();
        EventId = eventId;
        StartDate = startDate;
        EndDate = endDate;
        StartTime = startTime;
        EndTime = endTime;
        Status = EventStatus.Planned;
    }
    
    public void Complete()
    {
        EnsurePlanned();
        Status = EventStatus.Completed;
    }
    
    public void Cancel()
    {
        EnsurePlanned();
        Status = EventStatus.Cancelled;
    }
    
    private void EnsurePlanned()
    {
        if (Status != EventStatus.Planned )
            throw new DomainException($"Cannot change status: event is already {Status}");
    }
}