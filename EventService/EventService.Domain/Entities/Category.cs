using EventService.Domain.Expetions;

namespace EventService.Domain.Entities;

public class Category
{
    private readonly List<CategoryEvent> _categoryEvents = [];
    public IReadOnlyCollection<CategoryEvent> CategoryEvents => _categoryEvents.AsReadOnly();
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    private Category() {}

    public Category(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new DomainException("Category name cannot be null or empty.");
        
        Id = Guid.NewGuid();
        Name = name;
    }
}