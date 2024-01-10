using Application.Abstractions;
using Application.DapperQueries.JobQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Shared;

namespace Application.Features.Commands.JobCommands.DeleteJob;

public sealed class DeleteJobCommandHandler(IJobQuery jobQuery, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteJobCommand>
{
    private readonly IJobQuery _jobQuery = jobQuery;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobQuery.GetToDelete(request.JobId);
        if (job is null)
            return Result.Fail("Job not found");

        await _unitOfWork.JobRepository.DeleteAsync(job);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to delete job");

        return Result.Ok("Job Deleted Successfully");
    }
}