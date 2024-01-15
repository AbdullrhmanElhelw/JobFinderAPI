using Application.DTOs.ApplicantDTOs;
using Application.DTOs.ExperienceDTOs;
using Application.Features.Commands.ApplicantCommands.ApplicantLogin;
using Application.Features.Commands.ApplicantCommands.ApplicantRegister;
using Application.Features.Commands.ApplicantCommands.CreateExperience;
using Application.Features.Commands.ApplicantCommands.DeleteExperience;
using Application.Features.Commands.ApplicantCommands.DeleteSkill;
using Application.Features.Commands.ApplicantCommands.PartialUpdate;
using Application.Features.Commands.ApplicantCommands.UpdateApplicant;
using Application.Features.Commands.ApplicantCommands.UpdateExperience;
using Application.Features.Commands.ApplicantSkills;
using Application.Features.Queries.ApplicantQueries.GetAllApplicants;
using Application.Features.Queries.ApplicantQueries.GetApplicantJobs;
using Application.Features.Queries.ApplicantQueries.GetApplicantSkills;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(RolesEnum.Applicant))]
[Authorize(Roles = nameof(RolesEnum.Admin))]
public class ApplicantController(ISender sender)
    : ApiController(sender)
{
    private readonly ISender _sender = sender;

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> ApplicantRegister([FromBody] RegisterApplicantDTO registerApplicantDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new ApplicantRegisterCommand
            (registerApplicantDTO.Email, registerApplicantDTO.Password, registerApplicantDTO.ConfirmPassword, registerApplicantDTO.FirstName, registerApplicantDTO.LastName, "localhost"), cancellationToken);

        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> ApplicantLogin([FromBody] LoginApplicantDTO loginApplicantDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new ApplicantLoginCommand(loginApplicantDTO.Email, loginApplicantDTO.Password), cancellationToken);

        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("AddSkill")]
    [Authorize(Roles = nameof(RolesEnum.Applicant))]
    public async Task<IActionResult> CreateApplicantSkill([FromBody] CreateSkillCommand createApplicantSkillDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new CreateSkillCommand(createApplicantSkillDTO.ApplicantId, createApplicantSkillDTO.SkillId));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("CreateExperience")]
    public async Task<IActionResult> CreateExperience([FromBody] CreateExperienceDTO createExperienceCommand, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new CreateExperienceCommand(createExperienceCommand.Title, createExperienceCommand.Company, createExperienceCommand.Location, createExperienceCommand.StartDate, createExperienceCommand.EndDate, createExperienceCommand.Description, createExperienceCommand.IsCurrent, createExperienceCommand.ApplicantId), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("ApplicantSkills/{id:int}")]
    [Authorize(Roles = nameof(RolesEnum.Applicant))]
    public async Task<IActionResult> GetApplicantSkills(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetApplicantSkillQuery(id), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("ApplicantWithJobs/{id:int}")]
    public async Task<IActionResult> GetApplicantWithJobs(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetApplicantJobsQuery(id), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("GetAllApplicants")]
    public async Task<IActionResult> GetAllApplicants(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllApplicantsQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpDelete("DeleteSkill/{applicantId:int}/{skillId:int}")]
    [Authorize(Roles = nameof(RolesEnum.Applicant))]
    public async Task<IActionResult> DeleteSkill(int applicantId, int skillId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new DeleteApplicantSkillCommand(applicantId, skillId), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpDelete("Delete/{applicantId:int}/{experienceId:int}")]
    public async Task<IActionResult> Delete(int applicantId, int experienceId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new DeleteExperienceCommand(applicantId, experienceId), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPut("UpdateApplicant/{id:int}")]
    [Authorize(Roles = nameof(RolesEnum.Applicant))]
    public async Task<IActionResult> UpdateApplicant(int id, [FromBody] UpdateApplicantDTO updateApplicantDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateApplicantCommand(id, updateApplicantDTO.FirstName, updateApplicantDTO.LastName), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPut("UpdateExperience/{applicantId:int}/{experienceId:int}")]
    public async Task<IActionResult> UpdateExperience(int applicantId, int experienceId, [FromBody] UpdateExperienceDTO updateExperienceDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateExperienceCommand(applicantId, experienceId, updateExperienceDTO.Title, updateExperienceDTO.Company, updateExperienceDTO.Location, updateExperienceDTO.Description, updateExperienceDTO.StartDate, updateExperienceDTO.EndDate), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPatch("PartialUpdateApplicant")]
    public async Task<IActionResult> PartialUpdateApplicant([FromQuery] string Email, JsonPatchDocument applicant, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new PartialUpdateApplicantCommand(Email, applicant), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}