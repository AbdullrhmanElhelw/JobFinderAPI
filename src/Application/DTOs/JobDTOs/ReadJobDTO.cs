namespace Application.DTOs.JobDTOs;

public record ReadJobDTO
    (int Id, string Title, string Description, int CompanyId, string CompanyName, int EmployerId, string EmployerName);