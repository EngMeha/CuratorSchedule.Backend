using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.UpdateGroup;

public record UpdateGroupCommand(
    Guid Id,
    string Name,
    int CountStudents): IRequest<ErrorOr<Guid>>;