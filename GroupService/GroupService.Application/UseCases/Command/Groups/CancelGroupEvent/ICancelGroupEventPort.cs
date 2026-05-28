using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.CancelGroupEvent;

public interface ICancelGroupEventPort: IPortMarker
{
    Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken);
    void Cancel(GroupEvent groupEvent);
}