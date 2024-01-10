using Application.Abstractions;

namespace Application.Features.Queries.CompanyQueries.FindCompany;

public record FindCompanyQuery(string Filter) : IQuery<IQueryable<FindCompanyResponse>>;

