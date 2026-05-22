using ErrorOr;
using GroupService.Application.Interfaces;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.DeleteGroup;

public class DeleteGroupHandler: IRequestHandler<DeleteGroupCommand, ErrorOr<Success>>
{
    private readonly IDeleteGroupPort _deleteGroupPort;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGroupHandler(IDeleteGroupPort deleteGroupPort, IUnitOfWork unitOfWork)
    {
        _deleteGroupPort = deleteGroupPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Success>> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _deleteGroupPort.GetByIdAsync(request.Id, cancellationToken);
        if (group == null)
            return Error.NotFound("Group.NotFound");
        
        _deleteGroupPort.Delete(group);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success;
    }
}