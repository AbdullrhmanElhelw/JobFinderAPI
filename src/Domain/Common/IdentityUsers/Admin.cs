namespace Domain.Common.IdentityUsers;

public class Admin : ApplicationUser
{
    #region Properties

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    #endregion Properties
}