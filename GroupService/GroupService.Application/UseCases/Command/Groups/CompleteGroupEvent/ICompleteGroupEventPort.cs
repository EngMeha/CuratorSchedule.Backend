using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.CompleteGroupEvent;

public interface ICompleteGroupEventPort: IPortMarker
{
    Task<GroupEvent?> GetGroupEvents(Guid groupId, Guid eventId, CancellationToken cancellationToken);
    void Complete(GroupEvent groupEvent, int actualCountStudent);
}