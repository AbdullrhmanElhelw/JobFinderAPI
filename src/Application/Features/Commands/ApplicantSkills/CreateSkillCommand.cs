using Application.Abstractions;

namespace Application.Features.Commands.ApplicantSkills;

public sealed record CreateSkillCommand
    (int ApplicantId, int SkillId) : ICommand;
