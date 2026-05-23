using GroupService.Application.UseCases.Command.Groups.AddEventToGroup;
using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfAddEventToGroupAdapter: IAddEventToGroupPort
{
    private readonly GroupContext _context;

    public EfAddEventToGroupAdapter(GroupContext context)
    {
        _context = context;
    }

    public async Task<Group?> GetGroupByIdAsync(Guid groupId, CancellationToken cancellationToken)
    {
        return await _context.Groups
            .Include(g => g.GroupEvents)
            .FirstOrDefaultAsync(g => g.Id == groupId, cancellationToken);
    }

    public async Task<EventProjection?> GetEventByIdAsync(Guid eventId, CancellationToken cancellationToken)
    {
        return await _context.EventProjections.FirstOrDefaultAsync(e => e.EventId == eventId, cancellationToken);
    }

    public async Task AddGroupEvent(GroupEvent groupEvent, CancellationToken cancellationToken)
    {
        await _context.GroupEvents.AddAsync(groupEvent, cancellationToken);
    }
    
}