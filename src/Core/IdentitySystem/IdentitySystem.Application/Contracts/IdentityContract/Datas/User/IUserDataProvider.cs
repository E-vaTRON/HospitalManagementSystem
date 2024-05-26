namespace IdentitySystem.Application;

public interface IUserDataProvider : IIdentityDataProviderBase<User, string>, IUserManagerProvider
{
}
