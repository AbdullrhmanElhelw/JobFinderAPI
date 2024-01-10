using Domain.Common.IdentityUsers;

namespace Domain.Models;

public class CompanyJob
{
    #region Relationships

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public int JobId { get; set; }
    public Job? Job { get; set; }

    public DateTime SetedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }

    #endregion Relationships
}