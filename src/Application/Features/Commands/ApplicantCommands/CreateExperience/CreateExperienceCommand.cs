using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.CreateExperience;

public sealed record CreateExperienceCommand
    (
       string Title, string Company, string Location, DateTime StartDate,
       DateTime EndDate, string Description, bool IsCurrent, int ApplicantId
    )
    : ICommand;