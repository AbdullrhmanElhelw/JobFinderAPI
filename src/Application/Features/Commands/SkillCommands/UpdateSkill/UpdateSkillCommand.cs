using Application.Abstractions;

namespace Application.Features.Commands.SkillCommands.UpdateSkill;

public sealed record UpdateSkillCommand
    (int Id, string Name, string Description) : ICommand;
