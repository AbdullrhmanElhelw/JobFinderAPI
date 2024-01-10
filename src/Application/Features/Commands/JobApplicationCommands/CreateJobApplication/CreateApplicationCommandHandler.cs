using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.JobQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.JobApplicationCommands.CreateJobApplication;

public sealed class CreateApplicationCommandHandler(IApplicantQuery applicantQuery, IJobQuery jobQuery, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateApplicationCommand>
{
    private readonly IApplicantQuery _applicantQuery = applicantQuery;
    private readonly IJobQuery _jobQuery = jobQuery;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);
        if (applicant is null)
            return Result.Fail(Error.NotFound);

        var job = await _jobQuery.Get(request.JobId);
        if (job is null)
            return Result.Fail(Error.NotFound);

        var application = new ApplicantJob
        {
            ApplicantId = request.ApplicantId,
            JobId = request.JobId
        };

        await _unitOfWork.ApplicationRepository.AddAsync(application);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail(new Error("Saving Error"));

        return Result.Ok();
    }
}