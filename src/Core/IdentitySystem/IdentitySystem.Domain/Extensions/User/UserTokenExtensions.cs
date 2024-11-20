namespace IdentitySystem.Domain;

public static class UserTokenExtensions
{
    #region [ Public Method ]
    public static UserToken RemoveRelated(this UserToken userToken)
    {
        userToken.User = null!;
        return userToken;
    }
    #endregion
}
