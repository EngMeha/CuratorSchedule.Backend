using ErrorOr;
using GroupService.Application.Interfaces;
using GroupService.Domain.Entities;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.CreateGroup;

public class CreateGroupHandler: IRequestHandler<CreateGroupCommand, ErrorOr<Guid>>
{
    private readonly ICreateGroupPort _createGroupPort;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGroupHandler(ICreateGroupPort createGroupPort, IUnitOfWork unitOfWork)
    {
        _createGroupPort = createGroupPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Guid>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group
        {
            CountStudents = request.CountStudents,
            Name = request.Name
        };
        
        await _createGroupPort.AddAsync(group, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return group.Id;
    }
}