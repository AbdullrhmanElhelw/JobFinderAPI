using Domain.Models;

namespace Domain.Common.IdentityUsers;

public class Company : ApplicationUser
{
    #region Properties

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    #endregion Properties

    #region Relationships

    public ICollection<Employer> Employers { get; set; } = [];

    public ICollection<CompanyJob> CompanyJobs { get; set; } = [];

    #endregion Relationships
}