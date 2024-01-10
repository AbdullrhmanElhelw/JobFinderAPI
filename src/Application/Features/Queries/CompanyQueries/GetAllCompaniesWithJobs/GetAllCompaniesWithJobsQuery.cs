using Application.Abstractions;

namespace Application.Features.Queries.CompanyQueries.GetAllCompaniesWithJobs;

public sealed record GetAllCompaniesWithJobsQuery()
        : IQuery<IQueryable<GetAllCompaniesWithJobsResponse>>;
