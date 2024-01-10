using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.ResumeQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.ResumeCommands.DeleteResume;

public sealed record DeleteResumeCommandHandler(IUnitOfWork UnitOfWork, IApplicantQuery ApplicantQuery, IResumeQuery ResumeQuery)
    : ICommandHandler<DeleteResumeCommand>
{
    private readonly IUnitOfWork _unitOfWork = UnitOfWork;
    private readonly IApplicantQuery _applicantQuery = ApplicantQuery;
    private readonly IResumeQuery _resumeQuery = ResumeQuery;
    public async Task<Result> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);
        if (applicant is null)
            return Result.Fail("Applicant does not exist");

        var resume = await _resumeQuery.Get(request.ResumeId);
        if (resume is null)
            return Result.Fail($"Applicant With #{request.ApplicantId} does not has the Resume with #{request.ResumeId}");

        var resumeEntity = new Resume
        {
            Id = request.ResumeId,
            ApplicantId = request.ApplicantId,
            Content = resume.Content,
            Extension = resume.Extension,
            FileName = resume.FileName
        };

        await _unitOfWork.ResumeRepository.DeleteAsync(resumeEntity);
        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to delete resume");

        return Result.Ok();
    }
}
