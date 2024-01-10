using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.ResumeCommands.UploadResume;

public class UploadResumeCommandHandler(IUnitOfWork unitOfWork, IApplicantQuery applicantQuery)
    : ICommandHandler<UploadResumeCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IApplicantQuery _applicantQuery = applicantQuery;

    public async Task<Result> Handle(UploadResumeCommand request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);

        if (applicant is null)
            return Result.Fail(Error.NotFound);

        if (request.Resume is null || request.Resume.Length == 0)
            return Result.Fail(Error.Invalid);

        using var stream = new MemoryStream();
        await request.Resume.CopyToAsync(stream, cancellationToken);

        var resume = new Resume
        {
            ApplicantId = request.ApplicantId,
            Content = stream.ToArray(),
            Extension = Path.GetExtension(request.Resume.FileName),
            FileName = request.Resume.FileName
        };

        await _unitOfWork.ResumeRepository.AddAsync(resume);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail(new Error("Unable to upload resume"));

        return Result.Ok();
    }
}