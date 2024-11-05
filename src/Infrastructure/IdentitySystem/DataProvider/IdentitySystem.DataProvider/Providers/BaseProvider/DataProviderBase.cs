namespace IdentitySystem.DataProvider;

public abstract class DataProviderBase<TEntity, TEId, TModel, TMId> : IDataProviderBase<TEntity, TEId>
    where TEntity : class, IEntity<TEId>
    where TModel : class, IModel<TMId>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }

    public DbSet<TModel> DbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public DataProviderBase(IdentitySystemDbContext context, IMapper mapper)
    {
        DbContext = context;
        Mapper = mapper;

        DbSet = DbContext.Set<TModel>();
    }
    #endregion

    #region [ Internal Method ]
    #region [ Mapping ]
    protected virtual TMId ParseId(TEId id)
        => Mapper.Map<TMId>(id);

    [DebuggerStepThrough]
    protected virtual TModel? MapToDataModel(TEntity? entity)
        => Mapper.Map<TModel?>(entity);

    [DebuggerStepThrough]
    protected virtual TEntity? MapToEntity(TModel? dbEntity)
        => Mapper.Map<TEntity?>(dbEntity);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TModel> MapToDbEntities(IEnumerable<TEntity?> entities)
        => Mapper.Map<IEnumerable<TModel>>(entities);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TEntity> MapToEntities(IEnumerable<TModel?> dbEntities)
        => Mapper.Map<IEnumerable<TEntity>>(dbEntities);
    #endregion

    protected virtual Task<IQueryable<TEntity>> GetQueryableAsync(CancellationToken cancellationToken = default)
        => GetQueryableAsync(false, cancellationToken);

    protected virtual Task<IQueryable<TEntity>> GetQueryableAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return Task.FromResult(query.ProjectTo<TEntity>(Mapper.ConfigurationProvider));
    }

    protected virtual async Task<TModel?> InternalFindByIdAsync(TEId id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var mId = ParseId(id!);
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbEntity = await query.FirstOrDefaultAsync(x => x.Id!.Equals(mId), cancellationToken);
        return dbEntity;
    }
    #endregion

    #region [ Public Method ]
    public virtual async Task<IEnumerable<TEntity>> FindAllWithPredicateAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);
        return await query.WhereIf(predicate != null, predicate!).ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var dbEntities = await DbSet.ToListAsync(cancellationToken);
        return MapToEntities(dbEntities);
    }

    public virtual async Task<TEntity?> FindByIdAsync(TEId id, CancellationToken cancellationToken = default, bool isQuickFind = true)
    {
        var dbEntity = await InternalFindByIdAsync(id, isQuickFind, cancellationToken);
        return MapToEntity(dbEntity);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var dbEntity = MapToDataModel(entity);
        ArgumentNullException.ThrowIfNull(dbEntity, nameof(dbEntity));
        await DbSet.AddAsync(dbEntity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        var dbEntities = MapToDbEntities(entities);
        await DbSet.AddRangeAsync(dbEntities, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual Task AddRangeAsync(CancellationToken cancellationToken = default, params TEntity[] entities)
        => AddRangeAsync(entities, cancellationToken);

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var disableQuickFind = false;
        var dbEntity = await InternalFindByIdAsync(entity.Id, disableQuickFind, cancellationToken);

        if (dbEntity is null)
            ArgumentNullException.ThrowIfNull(dbEntity, nameof(dbEntity));
        else
        {
            Mapper.Map(entity, dbEntity);
            DbSet.Update(dbEntity);
        }
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        => DeleteByIdAsync(entity.Id, cancellationToken);

    public virtual async Task DeleteByIdAsync(TEId id, CancellationToken cancellationToken = default)
    {
        var disableQuickFind = false;
        var dbEntity = await InternalFindByIdAsync(id, disableQuickFind, cancellationToken);
        if (dbEntity == null) return;
        DbContext.Remove(dbEntity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        var ids = entities.Select(x => ParseId(x.Id)).ToList();
        DbContext.RemoveRange(DbSet.Where(x => ids.Contains(x.Id)));
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual Task DeleteRangeAsync(CancellationToken cancellationToken = default, params TEntity[] entities)
        => DeleteRangeAsync(entities, cancellationToken);
    #endregion
}

public abstract class DataProviderBase<TEntity, TModel>(IdentitySystemDbContext context, IMapper mapper)
    : DataProviderBase<TEntity, string, TModel, Guid>(context, mapper)
    where TEntity : class, Domain.IEntity<string>
    where TModel : class, DataProvider.IModel<Guid>
{
}

public abstract class DataProviderIntBase<TEntity, TModel>(IdentitySystemDbContext context, IMapper mapper)
    : DataProviderBase<TEntity, int, TModel, int>(context, mapper)
    where TEntity : class, Domain.IEntity<int>
    where TModel : class, DataProvider.IModel<int>
{
}