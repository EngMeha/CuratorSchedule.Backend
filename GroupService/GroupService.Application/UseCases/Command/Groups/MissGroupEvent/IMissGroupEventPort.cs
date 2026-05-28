using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.MissGroupEvent;

public interface IMissGroupEventPort: IPortMarker
{
    Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken);
    void Miss(GroupEvent groupEvent);
}