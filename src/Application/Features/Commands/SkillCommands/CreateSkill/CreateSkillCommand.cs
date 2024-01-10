using Application.Abstractions;
using Domain.Enums.SkillLevels;

namespace Application.Features.Commands.SkillCommands.CreateSkill;

public sealed record CreateSkillCommand(string Name, string Description, Level Level)
    : ICommand;