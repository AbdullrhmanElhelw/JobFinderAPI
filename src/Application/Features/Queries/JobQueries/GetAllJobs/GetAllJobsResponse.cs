namespace Application.Features.Queries.JobQueries.GetAllJobs;

public sealed record GetAllJobsResponse
    (int Id, string Title, string Description, int CompanyId, string CompanyName, int EmployerId, string EmployerName);
