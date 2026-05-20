namespace GroupService.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public uint CountStudents { get; set; }
    public List<GroupEvent> GroupEvents { get; set; } = [];
}