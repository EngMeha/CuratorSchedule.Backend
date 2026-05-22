using GroupService.Application.UseCases.Query.Groups.GetGroup;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.QueryObjects;

public class EfGroupQuery: IGroupQuery
{
    private readonly GroupContext _context;

    public EfGroupQuery(GroupContext context)
    {
        _context = context;
    }

    public async Task<GetGroupResponse?> ExecuteAsync(GetGroupQuery query, CancellationToken cancellationToken = default)
    {
        return await _context.Groups
            .Select(x=> new GetGroupResponse()
            {
                CountStudents = x.CountStudents,
                Id = x.Id,
                Name = x.Name,
            })
            .FirstOrDefaultAsync(x => x.Id == query.Id);
    }
}