using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.MissEvent;

public interface IMissEventPort: IPortMarker
{
    Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken);
    void Miss(GroupEvent groupEvent, CancellationToken cancellationToken);
}