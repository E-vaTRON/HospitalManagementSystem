namespace HospitalManagementSystem.DataProvider;

public abstract class DataProviderBase<TDbContext, TEntity, TEId, TModel, TMId> : IDataProviderBase<TEntity, TEId>
    where TDbContext : DbContext
    where TEntity : class, IEntity<TEId>
    where TModel : class, IModel<TMId>
{
    protected IMapper Mapper { get; set; }

    public TDbContext DbContext { get; protected set; }

    public DbSet<TModel> DbSet { get; protected set; }

    public DataProviderBase(TDbContext context, IMapper mapper)
    {
        DbContext = context;
        Mapper = mapper;

        DbSet = DbContext.Set<TModel>();
    }

    public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);
        return await query.WhereIf(predicate != null, predicate!).ToListAsync(cancellationToken);
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
        Mapper.Map(entity, dbEntity);
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

    protected virtual async Task<TModel?> InternalFindByIdAsync(TEId id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var dbId = ParseId(id!);
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbEntity = await query.FirstOrDefaultAsync(x => x.Id!.Equals(dbId), cancellationToken);
        return dbEntity;
    }

    protected virtual TMId ParseId(TEId id) => Mapper.Map<TMId>(id);

    protected virtual Task<IQueryable<TEntity>> GetQueryableAsync(CancellationToken cancellationToken = default)
        => GetQueryableAsync(false, cancellationToken);

    protected virtual Task<IQueryable<TEntity>> GetQueryableAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return Task.FromResult(query.ProjectTo<TEntity>(Mapper.ConfigurationProvider));
    }

    [DebuggerStepThrough]
    protected virtual TModel? MapToDataModel(TEntity? entity)
        => Mapper.Map<TModel?>(entity);

    [DebuggerStepThrough]
    protected virtual TEntity? MapToEntity(TModel? dbEntity)
        => Mapper.Map<TEntity?>(dbEntity);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TModel> MapToDbEntities(IEnumerable<TEntity?> entities)
        => Mapper.Map<IEnumerable<TModel>>(entities);
}

public abstract class DataProviderBase<TDbContext, TEntity, TModel>(TDbContext context, IMapper mapper)
    : DataProviderBase<TDbContext, TEntity, string, TModel, string>(context, mapper)
    where TDbContext : DbContext
    where TEntity : class, Domain.IEntity<string>
    where TModel : class, DataProvider.IModel<string>
{
}