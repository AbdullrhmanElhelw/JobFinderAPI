using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController
    : ControllerBase
{
    protected readonly ISender sender;

    protected ApiController(ISender sender) => this.sender = sender;

    protected IActionResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult =>
             BadRequest(
                CreateProblemDetails(
                    "Validation error", StatusCodes.Status400BadRequest,
                    result.Error!,
                    validationResult.Errors)
                ),

            _ =>
             BadRequest(
                CreateProblemDetails(
                    "Validation error", StatusCodes.Status400BadRequest,
                    result.Error!)
                ),
        };
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new ProblemDetails
        {
            Title = title,
            Status = status,
            Detail = error.Message,
            Extensions =
            {
                ["errors"] = errors
            }
        };
}