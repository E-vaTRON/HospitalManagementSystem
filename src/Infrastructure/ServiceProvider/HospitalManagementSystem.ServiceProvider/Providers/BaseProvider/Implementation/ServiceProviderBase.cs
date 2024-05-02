namespace HospitalManagementSystem.ServiceProvider;

public abstract class ServiceProviderBase<TEntity, TEId> : IServiceProviderBase<TEntity, TEId>
    where TEntity : class, IEntity<TEId>
{
    public ServiceProviderBase()
    {
    }

    public Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> FindByIdAsync(TEId id, CancellationToken cancellationToken = default, bool isQuickFind = true)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(CancellationToken cancellationToken = default, params TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(TEId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(CancellationToken cancellationToken = default, params TEntity[] entities)
    {
        throw new NotImplementedException();
    }
}

public abstract class ServiceProviderBase<TEntity> : ServiceProviderBase<TEntity, string>
    where TEntity : class, Domain.IEntity<string>
{
}