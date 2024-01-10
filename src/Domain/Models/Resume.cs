using Domain.Common.IdentityUsers;

namespace Domain.Models;

public class Resume
{
    #region properties

    public int Id { get; set; }
    public byte[] Content { get; set; } = [];
    public string Extension { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;

    #endregion properties

    #region relationships

    public int ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }

    #endregion relationships
}