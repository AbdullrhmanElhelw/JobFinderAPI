using Application.DTOs.SkillDTOs;
using Application.Features.Commands.SkillCommands.CreateMultiSkills;
using Application.Features.Commands.SkillCommands.CreateSkill;
using Application.Features.Commands.SkillCommands.DeleteSkill;
using Application.Features.Commands.SkillCommands.PartialUpdate;
using Application.Features.Commands.SkillCommands.UpdateSkill;
using Application.Features.Queries.SkillQueries.FindSkill;
using Application.Features.Queries.SkillQueries.GetAll;
using Application.Features.Queries.SkillQueries.GetAllWithPaging;
using Application.Features.Queries.SkillQueries.GetById;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SkillController(ISender sender)
    : ApiController(sender)
{
    private readonly ISender _sender = sender;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllSkills(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllSkillQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSkillById(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSkillByIdQuery(id), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("{filter}")]
    public async Task<IActionResult> GetAllSkillsByFilter(string filter, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new FindSkillQuery(filter), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("GetAll/{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetAllSkillsWithPaging(int pageNumber, int pageSize, CancellationToken cancellationToken, [FromQuery] string filter = "", [FromQuery] string sortOrder = "")
    {
        var result = await _sender.Send(new GetAllSkillsWithPagingQuery(pageSize, pageNumber, filter, sortOrder), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public async Task<IActionResult> CreateSkill([FromBody] CreateSkillDTO job, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new CreateSkillCommand(job.Name, job.Description, job.Level));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("multiple")]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public async Task<IActionResult> CreateMultipleSkills([FromBody] List<CreateSkillDTO> skills, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new CreateMultiSkillsCommand(skills));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public async Task<IActionResult> UpdateSkill(int id, UpdateSkillDTO skill, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateSkillCommand(id, skill.Name, skill.Description), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPatch("partial-update/{id}")]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public async Task<IActionResult> PartialUpdateSkill(int id, JsonPatchDocument skillPD, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new SkillPartialUpdateCommand(id, skillPD), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public async Task<IActionResult> DeleteSkill(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new DeleteSkillCommand(id), cancellationToken);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}