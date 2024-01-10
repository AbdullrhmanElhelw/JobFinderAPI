using Application.Abstractions;
using Application.DapperQueries.ExperienceQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Common.IdentityUsers;
using Domain.Models;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.ApplicantCommands.UpdateExperience;

public sealed class UpdateExperienceCommandHandler
    (UserManager<Applicant> userManager, IUnitOfWork unitOfWork, IExperienceQuery experienceQuery)
    : ICommandHandler<UpdateExperienceCommand>
{
    private readonly UserManager<Applicant> _userManager = userManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IExperienceQuery _experienceQuery = experienceQuery;

    public async Task<Result> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
    {
        var applicantExists = await _userManager.FindByIdAsync(request.ApplicantId.ToString());

        if (applicantExists is null)
            return Result.Fail("Applicant does not exist");

        var experience = await _experienceQuery.GetApplicantExperience(request.ExperienceId, request.ApplicantId);

        if (experience is null)
            return Result.Fail("Experience does not exist");

        var experienceToUpdate = new Experience
        {
            Id = request.ExperienceId,
            Title = request.Title,
            Company = request.CompanyName,
            Location = request.Location,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            ApplicantId = request.ApplicantId
        };

        _unitOfWork.ExperienceRepository.UpdateAsync(experienceToUpdate);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to update experience");

        return Result.Ok("Experience updated successfully");
    }
}