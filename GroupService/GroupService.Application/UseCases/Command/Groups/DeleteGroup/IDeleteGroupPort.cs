using GroupService.Application.Interfaces.Ports;
using GroupService.Domain.Entities;

namespace GroupService.Application.UseCases.Command.Groups.DeleteGroup;

public interface IDeleteGroupPort: IDeletePort<Group>, IGetByIdPort<Group>
{
    
}