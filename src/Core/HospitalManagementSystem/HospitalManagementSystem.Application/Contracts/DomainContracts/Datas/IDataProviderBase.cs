namespace HospitalManagementSystem.Application;

public interface IDataProviderBase
{
}

public interface IDataProviderBase<TEntity, TEId> : IContractBase<TEntity, TEId>
    where TEntity : class, IEntity<TEId>
{
}
