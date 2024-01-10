using Domain.Common.IdentityUsers;

namespace Domain.Models;

public class Job
{
    #region properties

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    #endregion properties

    #region relationships

    public int EmployerId { get; set; }
    public Employer? Employer { get; set; }

    public ICollection<ApplicantJob> Applicants { get; set; } = [];
    public ICollection<JobSkill> Skills { get; set; } = [];

    public ICollection<CompanyJob> CompanyJobs { get; set; } = [];

    #endregion relationships
}