using Microsoft.AspNetCore.Identity;

namespace Domain.Common.IdentityUsers;

public class ApplicationUser : IdentityUser<int>
{
    #region Properties

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    #endregion Properties
}