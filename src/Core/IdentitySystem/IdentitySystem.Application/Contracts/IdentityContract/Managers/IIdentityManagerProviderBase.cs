namespace IdentitySystem.Application;

public interface IIdentityManagerProviderBase<TEntity, TEId> : IIdentityContractBase<TEntity, TEntity, TEId>
    where TEntity : class
{
}