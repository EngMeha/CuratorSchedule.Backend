using GroupService.Application.UseCases.Query.Groups.GetGroups;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.QueryObjects;

public class EfGroupsQuery: IGroupsQuery
{
    private readonly GroupContext _context;

    public EfGroupsQuery(GroupContext context)
    {
        _context = context;
    }

    public async Task<List<GetGroupsResponse>> ExecuteAsync(GetGroupsQuery query, CancellationToken cancellationToken = default)
    {
        return await _context.Groups
            .Select(x => new GetGroupsResponse()
            {
                Id = x.Id,
                Name = x.Name,
                CountStudents = x.CountStudents
            }).ToListAsync(cancellationToken);
    }
}