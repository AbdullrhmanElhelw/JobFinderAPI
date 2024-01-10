namespace Application.DTOs.ApplicantDTOs;

public class ReadApplicantWithJobsDTO
{
    public int Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;

    public List<ReadApplicantJobDTO> Jobs { get; set; } = new();
}

public sealed record ReadApplicantJobDTO
    (int Id, string Title, string JobDescription, string Name, string CompanyDescription, int EmployerId, string EmployerName, DateTime AppliedAt, bool IsReviewed);