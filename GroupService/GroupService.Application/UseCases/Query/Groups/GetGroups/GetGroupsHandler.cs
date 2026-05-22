using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Query.Groups.GetGroups;

public class GetGroupsHandler: IRequestHandler<GetGroupsQuery, ErrorOr<List<GetGroupsResponse>>>
{
    private readonly IGroupsQuery _groupsQuery;

    public GetGroupsHandler(IGroupsQuery groupsQuery)
    {
        _groupsQuery = groupsQuery;
    }

    public async ValueTask<ErrorOr<List<GetGroupsResponse>>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _groupsQuery.ExecuteAsync(request, cancellationToken); 
    }
}