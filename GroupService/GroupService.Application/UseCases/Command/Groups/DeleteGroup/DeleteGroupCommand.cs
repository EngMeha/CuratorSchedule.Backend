using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.DeleteGroup;

public record DeleteGroupCommand(Guid Id): IRequest<ErrorOr<Success>>;