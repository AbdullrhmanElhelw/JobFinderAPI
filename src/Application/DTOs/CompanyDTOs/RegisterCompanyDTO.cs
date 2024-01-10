namespace Application.DTOs.CompanyDTOs;

public record RegisterCompanyDTO
    (string Name, string Email, string Password, string ConfirmPassword, string Address, string City, string Country);

