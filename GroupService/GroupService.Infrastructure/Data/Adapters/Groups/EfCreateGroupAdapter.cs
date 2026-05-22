using GroupService.Application.UseCases.Command.Groups.CreateGroup;
using GroupService.Domain.Entities;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfCreateGroupAdapter: ICreateGroupPort
{
    private readonly GroupContext _context;

    public EfCreateGroupAdapter(GroupContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Group entity, CancellationToken cancellationToken = default)
    {
        await _context.Groups.AddAsync(entity, cancellationToken);
    }
}