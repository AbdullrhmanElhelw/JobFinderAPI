namespace Application.DTOs.ExperienceDTOs;

public record ReadExperienceDTO
    (int Id, string Title, string CompanyName, string Position, string Description, DateTime StartDate, DateTime EndDate);