namespace IdentitySystem.Domain;

public static class UserRoleExtensions
{
    #region [ Public Method ]
    public static UserRole RemoveRelated(this UserRole userRole)
    {
        userRole.User = null!;
        userRole.Role = null!;
        return userRole;
    }
    #endregion
}
