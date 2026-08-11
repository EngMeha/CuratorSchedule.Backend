using ErrorOr;
using GroupService.Application.Interfaces;
using GroupService.Domain.Entities;
using Mediator;

namespace GroupService.Application.UseCases.Command.Groups.AddEventToGroup;

public class AddEventToGroupHandler: IRequestHandler<AddEventToGroupCommand, ErrorOr<Updated>>
{
    private readonly IAddEventToGroupPort _addEventToGroupPort;
    private readonly IUnitOfWork _unitOfWork;

    public AddEventToGroupHandler(IAddEventToGroupPort addEventToGroupPort, IUnitOfWork unitOfWork)
    {
        _addEventToGroupPort = addEventToGroupPort;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Updated>> Handle(AddEventToGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _addEventToGroupPort.GetGroupByIdAsync(request.GroupId, cancellationToken);
        var eventProjection = await _addEventToGroupPort.GetEventByIdAsync(request.EventId, cancellationToken);
        
        if (group == null || eventProjection == null)
            return Error.NotFound("Group.Event.NotFound", "Group or Event not found");

        if (group.GroupEvents.Any(e => e.EventProjectionId == eventProjection.Id))
            return Error.Conflict("EventGroup.Exist","Event is already in group");

        if (group.CountStudents < request.CountStudents)
            return Error.Validation("Students.TooMany","Students in request more than entity");
        
        var groupEvent = new GroupEvent(group.Id, eventProjection.Id, request.CountStudents);
        
        await _addEventToGroupPort.AddGroupEvent(groupEvent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}