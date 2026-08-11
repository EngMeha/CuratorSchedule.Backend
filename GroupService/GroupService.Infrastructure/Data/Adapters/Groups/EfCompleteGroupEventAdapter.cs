using GroupService.Application.UseCases.Command.Groups.CompleteGroupEvent;
using GroupService.Domain.Entities;
using GroupService.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Data.Adapters.Groups;

public class EfCompleteGroupEventAdapter: ICompleteGroupEventPort
{
    private readonly GroupContext _context;

    public EfCompleteGroupEventAdapter(GroupContext context)
    {
        _context = context;
    }

    public async Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken)
    {
        return await _context.GroupEvents
            .Where(x=> x.GroupId == groupId && x.EventProjection.EventId == eventId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public void Complete(GroupEvent groupEvent, int actualCountStudent)
    {
        groupEvent.Complete(actualCountStudent);
        _context.GroupEvents.Update(groupEvent);
    }
}