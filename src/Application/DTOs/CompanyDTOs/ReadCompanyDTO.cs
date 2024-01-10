namespace Application.DTOs.CompanyDTOs;

public record ReadCompanyDTO
    (int ID, string Name, string Description, string Country, string City, string Address, string Email);