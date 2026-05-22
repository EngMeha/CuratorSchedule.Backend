using GroupService.Application.UseCases.Command.Groups.UpdateGroup;
using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfUpdateGroupAdapter: IUpdateGroupPort
{
    private readonly GroupContext _context;

    public EfUpdateGroupAdapter(GroupContext context)
    {
        _context = context;
    }

    public void Update(Group entity)
    {
        _context.Update(entity);
    }

    public async Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Groups.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
    }
}