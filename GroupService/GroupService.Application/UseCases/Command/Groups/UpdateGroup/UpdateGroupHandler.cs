using ErrorOr;
using GroupService.Application.Interfaces;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.UpdateGroup;

public class UpdateGroupHandler: IRequestHandler<UpdateGroupCommand, ErrorOr<Guid>>
{
    private readonly IUpdateGroupPort _updateGroupPort;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGroupHandler(IUpdateGroupPort updateGroupPort, IUnitOfWork unitOfWork)
    {
        _updateGroupPort = updateGroupPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Guid>> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _updateGroupPort.GetByIdAsync(request.Id, cancellationToken);
        if (group == null)
            return Error.NotFound("Group.NotFound");

        group.Rename(request.Name);
        group.UpdateStudentsCount(request.CountStudents);
        
        _updateGroupPort.Update(group);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return group.Id;
    }
}