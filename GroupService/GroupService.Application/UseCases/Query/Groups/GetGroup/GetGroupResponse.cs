namespace GroupService.Application.UseCases.Query.Groups.GetGroup;

public record GetGroupResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; } = null!;
    public required int CountStudents { get; init; }
}