namespace IdentitySystem.Domain;

public static class RoleClaimExtensions
{
    #region [ Public Method ]
    public static RoleClaim RemoveRelated(this RoleClaim roleClaim)
    {
        roleClaim.Role = null!;
        return roleClaim;
    }
    #endregion
}
