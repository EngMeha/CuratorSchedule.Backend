using ErrorOr;
using GroupService.Application.Interfaces;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.CancelGroupEvent;

public class CancelGroupEventHandler: IRequestHandler<CancelGroupEventCommand, ErrorOr<Success>>
{
    private readonly ICancelGroupEventPort _cancelGroupEventPort;
    private readonly IUnitOfWork _unitOfWork;

    public CancelGroupEventHandler(ICancelGroupEventPort cancelGroupEventPort, IUnitOfWork unitOfWork)
    {
        _cancelGroupEventPort = cancelGroupEventPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Success>> Handle(CancelGroupEventCommand request, CancellationToken cancellationToken)
    {
        var groupEvent = await _cancelGroupEventPort.GetGroupEvents(request.GroupId, request.EventId, cancellationToken);
        
        if (groupEvent == null)
            return Error.NotFound("Group or event not found");
            
        _cancelGroupEventPort.Cancel(groupEvent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success;
    }
}