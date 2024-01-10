using Application.Abstractions;

namespace Application.Features.Queries.CompanyQueries.GetAllCompanies;

public sealed record GetAllCompaniesQuery() : IQuery<IQueryable<GetAllCompaniesResponse>>;