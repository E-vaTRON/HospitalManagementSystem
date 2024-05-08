namespace IdentitySystem.Application;

public interface IServiceProviderBase
{
}

public interface IServiceProviderBase<TEntity, TEId> : IContractBase<TEntity, TEId>
    where TEntity : class, IEntity<TEId>
{
}
