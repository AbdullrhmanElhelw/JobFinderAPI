using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.DeleteSkill;

public sealed record DeleteApplicantSkillCommand
    (int SkillId, int ApplicantId) : ICommand;