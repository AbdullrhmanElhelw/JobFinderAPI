using Domain.Common.IdentityUsers;

namespace Domain.Models;

public class ApplicantJob
{
    #region Relationships

    public int ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }

    public int JobId { get; set; }
    public Job? Job { get; set; }

    #endregion Relationships

    #region Properties

    public DateTime AppliedAt { get; set; } = DateTime.Now;

    public bool isAccepted { get; set; } = false;

    public bool isReviewed { get; set; } = false;

    public DateTime UpdatedAt { get; set; }

    #endregion Properties
}