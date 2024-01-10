using Application.Abstractions;

namespace Application.Features.Commands.SkillCommands.DeleteSkill;

public sealed record DeleteSkillCommand
    (int Id) : ICommand;