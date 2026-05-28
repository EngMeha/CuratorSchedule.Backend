using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.MissGroupEvent;

public record MissGroupEventCommand(Guid EventId, Guid GroupId): IRequest<ErrorOr<Success>>;