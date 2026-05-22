using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.CreateGroup;

public interface ICreateGroupPort: IAddPort<Group>
{
    
}