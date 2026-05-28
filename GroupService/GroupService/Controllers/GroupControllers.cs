using ErrorOr;
using GroupService.Application.UseCases.Command.Groups.AddEventToGroup;
using GroupService.Application.UseCases.Command.Groups.CancelGroupEvent;
using GroupService.Application.UseCases.Command.Groups.CompleteGroupEvent;
using GroupService.Application.UseCases.Command.Groups.CreateGroup;
using GroupService.Application.UseCases.Command.Groups.DeleteGroup;
using GroupService.Application.UseCases.Command.Groups.MissGroupEvent;
using GroupService.Application.UseCases.Command.Groups.UpdateGroup;
using GroupService.Application.UseCases.Query.Groups.GetGroup;
using GroupService.Application.UseCases.Query.Groups.GetGroups;
using GroupService.Controllers.Requests;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace GroupService.Controllers;

[ApiController]
[Route("api/groups")]
public class GroupControllers: BaseController
{
    private readonly IMediator _mediator;

    public GroupControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetGroupsResponse>>> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetGroupsQuery(), cancellationToken);

        return result.Match<ActionResult<List<GetGroupsResponse>>>(
            value => Ok(value),
            errors => Problem(errors.First().Description)
        );
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetGroupResponse>> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetGroupQuery(id), cancellationToken);

        return result.Match<ActionResult<GetGroupResponse>>(
            value => Ok(value),
            errors => Problem(errors.First().Description)
        );
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateGroupCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        
        return result.Match<ActionResult<Guid>>(
            value => Ok(value),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> Update(Guid id, UpdateGroupCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Invalid id");
        
        var result = await _mediator.Send(command, cancellationToken);
        
        return result.Match<ActionResult<Guid>>(
            value => Ok(value),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteGroupCommand(id), cancellationToken);

        return result.Match<ActionResult>(
            _ => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPost("{groupId:guid}/events")]
    public async Task<ActionResult> AddEvent(Guid groupId, AddEventToGroupRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddEventToGroupCommand(groupId, request.EventId, request.CountStudents), cancellationToken);

        return result.Match<ActionResult>(
            _ => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPost("{groupId:guid}/events/{eventId:guid}/miss")]
    public async Task<ActionResult> MissEvent(Guid groupId, Guid eventId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new MissGroupEventCommand(eventId, groupId), cancellationToken);
        return result.Match<ActionResult>(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("{groupId:guid}/events/{eventId:guid}/cancel")]
    public async Task<ActionResult> CancelEvent(Guid groupId, Guid eventId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CancelGroupEventCommand(eventId, groupId), cancellationToken);
        return result.Match<ActionResult>(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("{groupId:guid}/events/{eventId:guid}/complete")]
    public async Task<ActionResult> CompleteEvent(Guid groupId, Guid eventId, CompleteGroupEventRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CompleteGroupEventCommand(eventId, groupId, request.CountStudents), cancellationToken);
        return result.Match<ActionResult>(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
}