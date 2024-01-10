using Application.Abstractions;
using Application.DTOs.ApplicantDTOs;

namespace Application.Features.Queries.ApplicantQueries.GetApplicantJobs;

public sealed record GetApplicantJobsQuery
    (int Id) : IQuery<ReadApplicantWithJobsDTO>;