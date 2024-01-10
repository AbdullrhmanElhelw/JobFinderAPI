using Application.Abstractions;
using Application.DTOs.SkillDTOs;

namespace Application.Features.Commands.SkillCommands.CreateMultiSkills;

public record CreateMultiSkillsCommand
    (IEnumerable<CreateSkillDTO> Skills) : ICommand;