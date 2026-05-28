using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.MissEvent;

public record MissEventCommand(Guid EventId, Guid GroupId): IRequest<ErrorOr<Success>>;