using Application.DTOs.ResumeDTO;
using Application.Features.Commands.ResumeCommands.DeleteResume;
using Application.Features.Commands.ResumeCommands.UploadResume;
using Application.Features.Queries.ResumeQueries.GetResume;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(RolesEnum.Applicant))]
[Authorize(Roles = nameof(RolesEnum.Admin))]
public class ResumeController(ISender sender)
    : ApiController(sender)
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [ResumeValidator]
    public async Task<IActionResult> UploadResume([FromForm] UploadResumeDTO resume)
    {
        var result = await _sender.Send(new UploadResumeCommand(resume.ApplicantId, resume.Resume));
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetResume(int id)
    {
        var result = await _sender.Send(new GetResumeQuery(id));
        return result.IsSuccess ?
            File(result.Value.Content, "application/octet-stream", result.Value.FileName) :
            HandleFailure(result);
    }

    [HttpDelete("{applicantId:int}/{ResumeId:int}")]
    public async Task<IActionResult> DeleteResume(int applicantId, int ResumeId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new DeleteResumeCommand(applicantId, ResumeId), cancellationToken);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }
}