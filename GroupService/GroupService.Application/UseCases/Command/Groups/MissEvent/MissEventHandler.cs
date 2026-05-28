using ErrorOr;
using GroupService.Application.Interfaces;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.MissEvent;

public class MissEventHandler: IRequestHandler<MissEventCommand, ErrorOr<Success>>
{
    private readonly IMissEventPort _missEventPort;
    private readonly IUnitOfWork _unitOfWork;

    public MissEventHandler(IMissEventPort missEventPort, IUnitOfWork unitOfWork)
    {
        _missEventPort = missEventPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Success>> Handle(MissEventCommand request, CancellationToken cancellationToken)
    {
        var groupEvent = await _missEventPort.GetGroupEvents(request.GroupId, request.EventId, cancellationToken);
        
        if (groupEvent == null)
            return Error.NotFound("Group or event not found");
            
        _missEventPort.Miss(groupEvent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success;
    }
}