namespace EventService.Domain.Entities;

public class CategoryEvent
{
    public Guid Id { get; private set; }
    public Guid EventId { get; private set; }
    public Event Event { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    
    private CategoryEvent() {}
    
    public CategoryEvent(Guid eventId, Guid categoryId)
    {
        Id = Guid.NewGuid();
        EventId = eventId;
        CategoryId = categoryId;
    }
}