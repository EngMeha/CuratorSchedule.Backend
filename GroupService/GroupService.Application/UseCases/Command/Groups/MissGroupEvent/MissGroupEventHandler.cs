using ErrorOr;
using GroupService.Application.Interfaces;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.MissGroupEvent;

public class MissGroupEventHandler: IRequestHandler<MissGroupEventCommand, ErrorOr<Success>>
{
    private readonly IMissGroupEventPort _missGroupEventPort;
    private readonly IUnitOfWork _unitOfWork;

    public MissGroupEventHandler(IMissGroupEventPort missGroupEventPort, IUnitOfWork unitOfWork)
    {
        _missGroupEventPort = missGroupEventPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Success>> Handle(MissGroupEventCommand request, CancellationToken cancellationToken)
    {
        var groupEvent = await _missGroupEventPort.GetGroupEvents(request.GroupId, request.EventId, cancellationToken);
        
        if (groupEvent == null)
            return Error.NotFound("Group or event not found");
            
        _missGroupEventPort.Miss(groupEvent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success;
    }
}