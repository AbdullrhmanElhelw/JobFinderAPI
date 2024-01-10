using Application.Abstractions;
using Application.DTOs.ApplicantDTOs;

namespace Application.Features.Queries.ApplicantQueries.GetAllApplicants;

public sealed record GetAllApplicantsQuery
    : IQuery<IQueryable<ReadApplicantDTO>>;