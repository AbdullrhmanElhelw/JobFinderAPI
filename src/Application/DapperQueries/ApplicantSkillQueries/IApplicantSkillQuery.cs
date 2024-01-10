using Application.DTOs.ApplicantSkillDTO;

namespace Application.DapperQueries.ApplicantSkillQueries;

public interface IApplicantSkillQuery
{
    Task<ReadSkillDTO> GetApplicantSkill(int applicantId, int skillId);
}