namespace IdentitySystem.Application;

public interface IIdentityDataProviderBase<TEntity, TEId> : IIdentityManagerProviderBase<TEntity, TEId>
    where TEntity : class
{
}
