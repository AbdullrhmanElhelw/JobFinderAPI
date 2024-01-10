namespace Application.DTOs.CompanyDTOs;

public record ReadJobApplicantsDTO
{
    public int CompanyId { get; init; }
    public string CompanyName { get; init; } = "";
    public int JobId { get; init; }
    public string Title { get; init; } = "";
    public List<JobApplicantDto> Applicants { get; init; } = [];
}

public record JobApplicantDto
    (int ApplicantId, string FirstName, string LastName);