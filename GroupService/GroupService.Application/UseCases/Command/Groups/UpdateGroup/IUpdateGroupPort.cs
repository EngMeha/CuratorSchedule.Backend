using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.UpdateGroup;

public interface IUpdateGroupPort: IUpdatePort<Group>, IGetByIdPort<Group>
{
    
}