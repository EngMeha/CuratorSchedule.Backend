using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.CompleteGroupEvent;

public record CompleteGroupEventCommand(Guid EventId, Guid GroupId, int ActualCountStudent): IRequest<ErrorOr<Success>>;