namespace IdentitySystem.ServiceProvider;

public abstract class ServiceProviderBase<TEntity, TEId, TDataProvider> : IServiceProviderBase<TEntity, TEId>
    where TEntity : class, IEntity<TEId>
    where TDataProvider : IDataProviderBase<TEntity, TEId>
{
    #region [ Field ]
    protected TDataProvider DataProvider { get; set; }
    #endregion

    #region [ CTor ]
    public ServiceProviderBase(TDataProvider dataProvider)
    {
        this.DataProvider = dataProvider;
    }
    #endregion

    #region [ Public Method ]
    public Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        return DataProvider.FindAllAsync(predicate, cancellationToken);
    }

    public Task<TEntity?> FindByIdAsync(TEId? id, CancellationToken cancellationToken = default, bool isQuickFind = true)
    {
        if (id == null)
            ArgumentNullException.ThrowIfNull(id, "Id Is null");
        if (id is string str)
            ArgumentException.ThrowIfNullOrEmpty(str, "Id Is null or empty");

        return DataProvider.FindByIdAsync(id, cancellationToken, isQuickFind);
    }

    public Task AddAsync(TEntity? entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.AddAsync(entity, cancellationToken);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return DataProvider.AddRangeAsync(entities, cancellationToken);
    }

    public Task AddRangeAsync(CancellationToken cancellationToken = default, params TEntity[] entities)
    {
        return DataProvider.AddRangeAsync(cancellationToken, entities);
    }

    public Task UpdateAsync(TEntity? entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.UpdateAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return DataProvider.DeleteAsync(entity, cancellationToken);
    }

    public Task DeleteByIdAsync(TEId? id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        return DataProvider.DeleteByIdAsync(id, cancellationToken);
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return DataProvider.DeleteRangeAsync(entities, cancellationToken);
    }

    public Task DeleteRangeAsync(CancellationToken cancellationToken = default, params TEntity[] entities)
    {
        return DataProvider.DeleteRangeAsync(entities, cancellationToken);
    }
    #endregion
}

public abstract class ServiceProviderBase<TEntity>(IDataProviderBase<TEntity, string> dataProvider) 
    : ServiceProviderBase<TEntity, string, IDataProviderBase<TEntity, string>>(dataProvider)
    where TEntity : class, Domain.IEntity<string>
{
}