namespace Application.DTOs.ExperienceDTOs;

public record UpdateExperienceDTO
    (string Title, string Company, string Location, string Description, DateTime StartDate, DateTime EndDate, bool IsCurrent);