using Application.DTOs.ResumeDTO;

namespace Application.DapperQueries.ApplicantResumeQueries;

public interface IApplicantResume
{
    Task<GetResumeDTO> GetResume(int applicantId);
}
