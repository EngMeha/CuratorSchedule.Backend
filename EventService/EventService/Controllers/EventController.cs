using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Controllers;

public class EventController: ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }
}