namespace Application.Features.Queries.CompanyQueries.FindCompany;

public record FindCompanyResponse
    (int Id, string Name, string Email, string Address, string City, string Country);