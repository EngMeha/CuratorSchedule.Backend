using ErrorOr;
using Mediator;

namespace GroupService.Application.UseCases.Query.Groups.GetGroup;

public class GetGroupHandler: IRequestHandler<GetGroupQuery, ErrorOr<GetGroupResponse>>
{
    private readonly IGroupQuery _groupQuery;

    public GetGroupHandler(IGroupQuery groupQuery)
    {
        _groupQuery = groupQuery;
    }

    public async ValueTask<ErrorOr<GetGroupResponse>> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        var group = await _groupQuery.ExecuteAsync(request, cancellationToken);
        if (group == null)
            return Error.NotFound("Group.NotFound");

        return group;
    }
}