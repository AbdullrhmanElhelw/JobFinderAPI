namespace Application.DTOs.ExperienceDTOs;

public sealed record ReadExperienceWithApplicantDTO
    (int Id, string Title, string Company, string Location, string Description, DateTime StartDate, DateTime EndDate, bool IsCurrent, int ApplicantId, string ApplicantName);