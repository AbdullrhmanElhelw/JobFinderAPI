using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.UpdateExperience;

public sealed record UpdateExperienceCommand
      (int ApplicantId, int ExperienceId, string Title, string CompanyName, string Location, string Description, DateTime StartDate, DateTime EndDate)
    : ICommand;