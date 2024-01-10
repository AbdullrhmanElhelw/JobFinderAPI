using Domain.Models;

namespace Domain.Common.IdentityUsers;

public class Applicant : ApplicationUser
{
    #region properties

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    #endregion properties

    #region relationships

    public ICollection<Resume> Resumes { get; set; } = [];
    public ICollection<ApplicantJob> Jobs { get; set; } = [];
    public ICollection<ApplicantSkill> JobsSkill { get; set; } = [];
    public ICollection<Experience> Experiences { get; set; } = [];

    #endregion relationships
}