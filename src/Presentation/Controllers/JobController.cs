using Application.DTOs.JobDTOs;
using Application.Features.Commands.JobCommands.CreateJob;
using Application.Features.Commands.JobCommands.DeleteJob;
using Application.Features.Commands.JobCommands.PartialUpdate;
using Application.Features.Commands.JobCommands.UpdateJob;
using Application.Features.Queries.JobQueries.FindJob;
using Application.Features.Queries.JobQueries.GetAllJobs;
using Application.Features.Queries.JobQueries.GetAllWithPaging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class JobController(ISender sender)
    : ApiController(sender)
{
    private readonly ISender _sender = sender;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllJobsQuery(), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpGet("GetAllWithPagination/{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetAllWithPagination
        (int pageNumber, int pageSize, CancellationToken cancellationToken, [FromQuery] string filter = "")
    {
        var result = await _sender.Send(new GetAllJobsWithPagingQuery(pageSize, pageNumber, filter), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpGet("{filter}")]
    public async Task<IActionResult> Find(string filter, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new FindJobQuery(filter), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateJobDTO createJobDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send
            (new CreateJobCommand(createJobDTO.Title, createJobDTO.Description, createJobDTO.EmployerId, createJobDTO.CompanyId), cancellationToken);
        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    // delte/{jobId}/{companyId}
    [HttpDelete("Delete/{jobId}")]
    public async Task<IActionResult> Delete(int jobId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new DeleteJobCommand(jobId), cancellationToken);
        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateJobDTO updateJobDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateJobCommand(updateJobDTO.Id, updateJobDTO.Title, updateJobDTO.Description, updateJobDTO.EmployerId), cancellationToken);
        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    [HttpPatch("PartialUpdate/{id:int}")]
    public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument jobDTO, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new JopPartialUpdateCommand(id, jobDTO), cancellationToken);
        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }
}