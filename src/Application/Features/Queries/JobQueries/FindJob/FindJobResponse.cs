namespace Application.Features.Queries.JobQueries.FindJob;

public sealed record FindJobResponse
     (int Id, string Title, string Description, int CompanyId, string CompanyName, int EmployerId, string EmployerName);