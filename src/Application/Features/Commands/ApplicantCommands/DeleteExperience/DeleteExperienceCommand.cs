using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.DeleteExperience;

public sealed record DeleteExperienceCommand
    (int ApplicantId, int ExperinceId) : ICommand;