using Application.DTOs.ExperienceDTOs;

namespace Application.DapperQueries.ExperienceQueries;

public interface IExperienceQuery
{
    Task<IQueryable<ReadExperienceDTO>> GetApplicantExperiences(int applicantId);

    Task<ReadExperienceWithApplicantDTO> GetApplicantExperience(int applicantId, int experienceId);
}