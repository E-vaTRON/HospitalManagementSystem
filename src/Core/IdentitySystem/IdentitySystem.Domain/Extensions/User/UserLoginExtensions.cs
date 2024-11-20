namespace IdentitySystem.Domain;

public static class UserLoginExtensions
{
    #region [ Public Method ]
    public static UserLogin RemoveRelated(this UserLogin userLogin)
    {
        userLogin.User = null!;
        return userLogin;
    }
    #endregion
}
