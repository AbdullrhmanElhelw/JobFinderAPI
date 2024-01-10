namespace Application.Features.Queries.CompanyQueries.GetAllCompanies;

public record GetAllCompaniesResponse
    (int ID, string Name, string Description, string Country, string City, string Address, string Email);