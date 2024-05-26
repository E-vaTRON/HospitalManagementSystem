namespace IdentitySystem.Application;

public interface IDataProviderBase
{
}

public interface IDataProviderBase<TEntity, TEId> : IContractBase<TEntity, TEntity, TEId>
    where TEntity : class, IEntity<TEId>
{
}
