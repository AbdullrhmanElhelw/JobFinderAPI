using Application.DTOs.ApplicationDTOs;
using Application.Features.Commands.JobApplicationCommands.CreateJobApplication;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(RolesEnum.Applicant))]
[Authorize(Roles = nameof(RolesEnum.Admin))]
public class ApplicationController(ISender sender)
    : ApiController(sender)
{
    private readonly ISender _sender = sender;

    [HttpPost("ApplyJob")]
    public async Task<IActionResult> ApplyJob([FromBody] CreateApplicationDTO application)
    {
        var result = await _sender.Send(new CreateApplicationCommand(application.JobId, application.ApplicantId));
        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }
}