using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.CancelGroupEvent;

public record CancelGroupEventCommand(Guid EventId, Guid GroupId): IRequest<ErrorOr<Success>>;