namespace IdentitySystem.Domain;

public class UserTokenFactory
{
    public static UserToken Create()
    {
        return new UserToken();
    }

    public static UserToken Create(string loginProvider, string name, string value, string userId)
    {
        return new UserToken()
        {
            LoginProvider = loginProvider,
            Name = name,
            Value = value,
            UserId = userId
        };
    }
}
