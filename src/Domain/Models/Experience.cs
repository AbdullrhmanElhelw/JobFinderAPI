using Domain.Common.IdentityUsers;

namespace Domain.Models;

public class Experience
{
    #region Properties

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsCurrent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }

    #endregion Navigation Properties
}