namespace IdentitySystem.Domain;

public static class UserClaimExtensions
{
    #region [ Public Method ]
    public static UserClaim RemoveRelated(this UserClaim userClaim)
    {
        userClaim.User = null!;
        return userClaim;
    }
    #endregion
}
