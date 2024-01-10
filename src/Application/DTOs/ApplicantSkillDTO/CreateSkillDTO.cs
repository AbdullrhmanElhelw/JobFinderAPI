using Domain.Enums.SkillLevels;

namespace Application.DTOs.ApplicantSkillDTO;

public record CreateSkillDTO
    (string Name, string Description, Level Level, int ApplicantId);
