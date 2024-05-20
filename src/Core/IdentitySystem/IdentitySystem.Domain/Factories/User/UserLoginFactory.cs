namespace IdentitySystem.Domain;

public class UserLoginFactory
{
    public static UserLogin Create()
    {
        return new UserLogin();
    }

    public static UserLogin Create(string loginProvider, string providerKey, string providerDisplayName, string userId)
    {
        return new UserLogin()
        {
            LoginProvider = loginProvider,
            ProviderKey = providerKey,
            ProviderDisplayName = providerDisplayName,
            UserId = userId
        };
    }
}
