namespace Application.Features.Queries.JobQueries.GetAllWithPaging;

public sealed record GetAllJobsWithPagingResponse
     (int Id, string Title, string Description, int CompanyId, string CompanyName, int EmployerId, string EmployerName);