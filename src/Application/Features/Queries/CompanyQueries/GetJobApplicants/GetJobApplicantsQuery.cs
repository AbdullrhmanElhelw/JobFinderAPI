using Application.Abstractions;
using Application.DTOs.CompanyDTOs;

namespace Application.Features.Queries.CompanyQueries.GetJobApplicants;

public sealed record GetJobApplicantsQuery
    (int CompanyId, int JobId) : IQuery<IQueryable<ReadJobApplicantsDTO>>;