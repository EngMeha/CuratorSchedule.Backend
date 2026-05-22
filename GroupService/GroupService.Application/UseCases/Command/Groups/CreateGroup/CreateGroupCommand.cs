using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.CreateGroup;

public record CreateGroupCommand(string Name, int CountStudents) : IRequest<ErrorOr<Guid>>;