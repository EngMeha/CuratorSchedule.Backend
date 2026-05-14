using Mediator;
using Microsoft.AspNetCore.Mvc;
using GroupService.Application.UseCases.Query;

namespace GroupService.Controllers;

[ApiController]
[Route("temp")]
public class TempController: ControllerBase
{
    private readonly IMediator _mediator;
    
    public TempController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public ActionResult Index(CancellationToken cancellationToken)
    {
        return Ok();
    }
}