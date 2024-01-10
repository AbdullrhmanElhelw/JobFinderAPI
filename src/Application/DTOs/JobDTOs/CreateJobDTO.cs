namespace Application.DTOs.JobDTOs;

public record CreateJobDTO
    (string Title, string Description, int EmployerId, int CompanyId);
