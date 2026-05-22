using GroupService.Application.Interfaces.QueryObjects;

namespace GroupService.Application.UseCases.Query.Groups.GetGroup;

public interface IGroupQuery: IQueryObject<GetGroupQuery, GetGroupResponse?>
{
    
}