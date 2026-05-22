using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Query.Groups.GetGroups;

public record GetGroupsQuery: IRequest<ErrorOr<List<GetGroupsResponse>>>;