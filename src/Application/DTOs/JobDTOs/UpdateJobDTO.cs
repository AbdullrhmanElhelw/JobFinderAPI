namespace Application.DTOs.JobDTOs;

public record UpdateJobDTO
    (int Id, string Title, string Description, int EmployerId);