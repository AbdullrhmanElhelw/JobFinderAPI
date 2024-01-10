using Application.Abstractions;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.JobCommands.CreateJob;

public class CreateJobCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateJobCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = new Job
        {
            Title = request.Title,
            Description = request.Description,
            EmployerId = request.EmployerId
        };

        var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.CompanyId);

        if (company is null)
            return Result.Fail(Error.NotFound);

        var companyJob = new CompanyJob
        {
            Company = company,
            Job = job
        };

        await _unitOfWork.JobRepository.AddAsync(job);
        await _unitOfWork.CompanyJobRepository.AddAsync(companyJob);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail(new Error("Saving Error"));

        return Result.Ok();
    }
}