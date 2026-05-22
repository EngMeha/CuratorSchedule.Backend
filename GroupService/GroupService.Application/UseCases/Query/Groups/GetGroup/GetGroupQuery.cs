using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Query.Groups.GetGroup;

public record GetGroupQuery(Guid Id): IRequest<ErrorOr<GetGroupResponse>>;