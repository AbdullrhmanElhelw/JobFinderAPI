using Application.Abstractions;
using Application.DapperQueries.JobQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.JobCommands.UpdateJob;

public sealed class UpdateJobCommandHandler(IUnitOfWork unitOfWork, IJobQuery jobQuery)
    : ICommandHandler<UpdateJobCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJobQuery _jobQuery = jobQuery;

    public async Task<Result> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobQuery.GetToUpdate(request.Id);
        if (job is null)
            return Result.Fail("Job not found.");

        var jobToUpdate = new Job
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            EmployerId = request.EmployerId
        };

        _unitOfWork.JobRepository.UpdateAsync(jobToUpdate);
        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to update job.");

        return Result.Ok("Updated Successfully");
    }
}