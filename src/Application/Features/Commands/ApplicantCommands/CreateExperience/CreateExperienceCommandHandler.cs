using Application.Abstractions;
using Application.Interfaces.UnitOfWork;
using Domain.Common.IdentityUsers;
using Domain.Models;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.ApplicantCommands.CreateExperience;

public sealed class CreateExperienceCommandHandler(IUnitOfWork unitOfWork, UserManager<Applicant> userManager)
    : ICommandHandler<CreateExperienceCommand>
{
    private readonly UserManager<Applicant> _userManager = userManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByIdAsync(request.ApplicantId.ToString());
        if (userExists == null)
            return Result.Fail("User does not exist");

        var experience = new Experience
        {
            Title = request.Title,
            Company = request.Company,
            Location = request.Location,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Description = request.Description,
            IsCurrent = request.IsCurrent,
            ApplicantId = request.ApplicantId
        };

        await _unitOfWork.ExperienceRepository.AddAsync(experience);
        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to create experience");

        return Result.Ok("Experience created successfully");
    }
}