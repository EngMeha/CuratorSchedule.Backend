using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.AddEventToGroup;

public interface IAddEventToGroupPort: IPortMarker
{
    Task<Group?> GetGroupByIdAsync(Guid groupId, CancellationToken cancellationToken);
    Task<EventProjection?> GetEventByIdAsync(Guid eventId, CancellationToken cancellationToken);
    
    Task AddGroupEvent(GroupEvent groupEvent, CancellationToken cancellationToken);
}