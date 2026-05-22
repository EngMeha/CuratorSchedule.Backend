using GroupService.Application.UseCases.Command.Groups.DeleteGroup;
using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfDeleteGroupAdapter: IDeleteGroupPort
{
    private readonly GroupContext _context;

    public EfDeleteGroupAdapter(GroupContext context)
    {
        _context = context;
    }
    
    public void Delete(Group entity)
    {
        _context.Groups.Remove(entity);
    }

    public async Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Groups.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
    }
}