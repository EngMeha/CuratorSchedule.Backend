using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace GroupService.Controllers;

public class BaseController: ControllerBase
{
    protected ActionResult ProblemFromErrors(List<Error> errors)
    {
        var error = errors.First();
        var status = error.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: status, detail: error.Description);
    }
}