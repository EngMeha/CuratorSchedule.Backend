using EventService.Domain.Expetions;
using EventService.Domain.ValueObjects;

namespace EventService.Domain.Entities;

public class Event
{
    private readonly List<CategoryEvent> _categoryEvents = [];
    
    public Guid Id { get; private set;  }
    public string Name { get; private set; }
    public string Place { get; private set; }
    public string Address { get; private set; }
    
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    
    public int TotalGroups { get; private set; }
    public double AvgAttendance { get; private set; }
    
    public EventStatus Status { get; private set; }
    
    public IReadOnlyCollection<CategoryEvent> CategoryEvents => _categoryEvents.AsReadOnly();

    private Event() {}
    
    public Event(string name, string place, string address, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime, List<CategoryEvent> categoryEvents)
    {
        
        if (string.IsNullOrEmpty(name))
            throw new DomainException("Name cannot be empty");
        
        if (string.IsNullOrEmpty(place))
            throw new DomainException("Place cannot be empty");
        
        if (string.IsNullOrEmpty(address))
            throw new DomainException("Address cannot be empty");
        
        if (startDate > endDate)
            throw new DomainException("Start date cannot be greater than end date");
        
        if (startDate == endDate && startTime >= endTime)
            throw new DomainException("Start time cannot be greater than end time");
        
        Id = Guid.NewGuid();
        Name = name;
        Place = place;
        Address = address;
        StartDate = startDate;
        EndDate = endDate;
        StartTime = startTime;
        EndTime = endTime;
        Status = EventStatus.Planned;
        _categoryEvents = categoryEvents is null ? [] : new (categoryEvents);
    }
    
    public void ApplyCompletionStats(int totalGroups, double avgAttendance)
    {
        EnsurePlanned();
        
        if (totalGroups < 0)
            throw new DomainException("Total groups cannot be negative");
        
        if(avgAttendance is < 0 or > 100)
            throw new DomainException("Avg attendance must be between 0 and 100");
        
        TotalGroups = totalGroups;
        AvgAttendance = avgAttendance;
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
            throw new DomainException("Cannot change status: event is already {Status}");
    }
}