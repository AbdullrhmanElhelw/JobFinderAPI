using Application.Abstractions;

namespace Application.Features.Queries.ResumeQueries.GetResume;

public record GetResumeQuery(int ApplicantId) : IQuery<GetResumeResponse>;