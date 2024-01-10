using Domain.Models;

namespace Domain.Common.IdentityUsers;

public class Employer : ApplicationUser
{
    #region properties

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    #endregion properties

    #region relationships

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public ICollection<Job> Jobs { get; set; } = [];

    #endregion relationships
}