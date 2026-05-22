using GroupService.Application.Interfaces.QueryObjects;

namespace GroupService.Application.UseCases.Query.Groups.GetGroups;

public interface IGroupsQuery: IQueryObject<GetGroupsQuery, List<GetGroupsResponse>>
{
    
}