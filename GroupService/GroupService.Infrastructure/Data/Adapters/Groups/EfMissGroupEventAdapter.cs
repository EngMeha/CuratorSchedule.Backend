using GroupService.Application.UseCases.Command.Groups.MissGroupEvent;
using GroupService.Domain.Entities;
using GroupService.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfMissGroupEventAdapter: IMissGroupEventPort
{
    private readonly GroupContext _context;

    public EfMissGroupEventAdapter(GroupContext context)
    {
        _context = context;
    }

    public async Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken)
    {
        return await _context.GroupEvents
            .Where(x=> x.GroupId == groupId && x.EventProjection.EventId == eventId)
            .FirstOrDefaultAsync(cancellationToken);
    }
    
    public void Miss(GroupEvent groupEvent)
    {
        groupEvent.Status = EventStatus.Missed;
        _context.GroupEvents.Update(groupEvent);
    }
}