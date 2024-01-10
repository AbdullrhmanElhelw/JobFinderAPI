namespace Application.DTOs.EmployerDTOs;

public sealed record RegisterEmployerDTO
     (string Email, string Password, string ConfirmPassword, string FirstName, string LastName, int CompanyId);