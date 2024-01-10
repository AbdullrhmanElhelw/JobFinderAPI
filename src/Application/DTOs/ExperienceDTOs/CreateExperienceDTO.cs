namespace Application.DTOs.ExperienceDTOs;

public record CreateExperienceDTO
    (
        string Title, string Company, string Location, DateTime StartDate, DateTime EndDate,
        string Description, bool IsCurrent, int ApplicantId
    );