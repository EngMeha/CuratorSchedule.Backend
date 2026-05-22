namespace GroupService.Application.UseCases.Query.Groups.GetGroups;

public record GetGroupsResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int CountStudents { get; init; }
}