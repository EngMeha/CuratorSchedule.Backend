using ErrorOr;
using GroupService.Application.Interfaces;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.CompleteGroupEvent;

public class CompleteGroupEventHandler: IRequestHandler<CompleteGroupEventCommand, ErrorOr<Success>>
{
    private readonly ICompleteGroupEventPort _completeGroupEventPort;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteGroupEventHandler(ICompleteGroupEventPort completeGroupEventPort, IUnitOfWork unitOfWork)
    {
        _completeGroupEventPort = completeGroupEventPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Success>> Handle(CompleteGroupEventCommand request, CancellationToken cancellationToken)
    {
        if (request.ActualCountStudent < 0)
            return Error.Validation("Students.TooLittle", "Students in request very few");
        
        var groupEvent = await _completeGroupEventPort.GetGroupEvents(request.GroupId, request.EventId, cancellationToken);
        
        if (groupEvent == null)
            return Error.NotFound("Group or event not found");
            
        _completeGroupEventPort.Complete(groupEvent, request.ActualCountStudent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success;
    }
}