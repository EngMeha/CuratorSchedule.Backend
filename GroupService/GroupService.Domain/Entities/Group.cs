using GroupService.Domain.Exceptions;

namespace GroupService.Domain.Entities;

public class Group
{
    private readonly List<GroupEvent> _groupEvents = [];
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int CountStudents { get; private set; }
    public IReadOnlyCollection<GroupEvent> GroupEvents => _groupEvents.AsReadOnly();
    
    private Group() {}

    public Group(string name, int countStudents, List<GroupEvent> groupEvents)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Group name cannot be null or empty.");
        
        if (countStudents <= 0)
            throw new DomainException("Number of students must be greater than zero.");
        
        _groupEvents =  groupEvents is null ? new (): new(groupEvents);
            
        Id = Guid.NewGuid();
        Name = name.Trim();
        CountStudents = countStudents;
    }
}