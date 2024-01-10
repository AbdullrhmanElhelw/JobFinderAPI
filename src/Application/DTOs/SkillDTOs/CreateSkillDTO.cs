using Domain.Enums.SkillLevels;

namespace Application.DTOs.SkillDTOs;

public record CreateSkillDTO
    (string Name, string Description, Level Level);