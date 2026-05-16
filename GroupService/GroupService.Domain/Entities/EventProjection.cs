namespace GroupService.Domain.Entities;

public class EventProjection
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<GroupEvent> GroupEvents { get; set; }
}