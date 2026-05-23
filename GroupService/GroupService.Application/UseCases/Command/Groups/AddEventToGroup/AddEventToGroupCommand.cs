using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.AddEventToGroup;

public record AddEventToGroupCommand(Guid GroupId, Guid EventId, int CountStudents) : IRequest<ErrorOr<Updated>>;

