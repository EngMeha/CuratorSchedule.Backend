using GroupService.Application.UseCases.Command.Groups.CancelGroupEvent;
using GroupService.Domain.Entities;
using GroupService.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfCancelGroupEventAdapter: ICancelGroupEventPort
{
    private readonly GroupContext _context;

    public EfCancelGroupEventAdapter(GroupContext context)
    {
        _context = context;
    }

    public async Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken)
    {
        return await _context.GroupEvents
            .Where(x=> x.GroupId == groupId && x.EventProjection.EventId == eventId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public void Cancel(GroupEvent groupEvent)
    {
        groupEvent.Status = EventStatus.Cancelled;
        _context.Update(groupEvent);
    }
}