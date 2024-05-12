namespace HospitalManagementSystem.ServiceProvider;

public abstract class ServiceProviderBase<TDto, TDId, TEntity, TEId, TDataProvider> : IServiceProviderBase<TDto, TDId>
    where TDto : class, Application.IDataObject<TDId>
    where TEntity : class, IEntity<TEId>
    where TDataProvider : IDataProviderBase<TEntity, TEId>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }
    protected TDataProvider DataProvider { get; set; }
    #endregion

    #region [ CTor ]
    public ServiceProviderBase(TDataProvider dataProvider, IMapper mapper)
    {
        Mapper = mapper;

        DataProvider = dataProvider;
    }
    #endregion

    #region [ Internal Method ]
    #region [ Mapping ]
    protected virtual TEId ParseId(TDId id)
        => Mapper.Map<TEId>(id);

    [DebuggerStepThrough]
    protected virtual TEntity? MapToEntity(TDto? dto)
        => Mapper.Map<TEntity?>(dto);

    [DebuggerStepThrough]
    protected virtual TDto? MapToDTO(TEntity? dbEntity)
        => Mapper.Map<TDto?>(dbEntity);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TEntity> MapToEntities(IEnumerable<TDto?> dtos)
        => Mapper.Map<IEnumerable<TEntity>>(dtos);

    [DebuggerStepThrough]
    protected virtual TEntity[] MapToEntities(params TDto[] dtos)
        => Mapper.Map<TEntity[]>(dtos);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TDto> MapToDTOs(IEnumerable<TEntity?> entities)
        => Mapper.Map<IEnumerable<TDto>>(entities);

    [DebuggerStepThrough]
    protected virtual Expression<Func<TEntity, bool>> MapToEntityPredicate(Expression<Func<TDto, bool>>? dtoPredicate)
        => Mapper.Map<Expression<Func<TEntity, bool>>>(dtoPredicate);
    #endregion

    #endregion

    #region [ Public Method ]
    public virtual async Task<IEnumerable<TDto>> FindAllAsync(Expression<Func<TDto, bool>>? dtoPredicate = null, CancellationToken cancellationToken = default)
    {
        var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
        var entities = await DataProvider.FindAllAsync(entityPredicate, cancellationToken);
        return MapToDTOs(entities);
    }

    public virtual async Task<TDto?> FindByIdAsync(TDId? id, CancellationToken cancellationToken = default, bool isQuickFind = true)
    {
        if (id == null)
            ArgumentNullException.ThrowIfNull(id, "Id Is null");
        if (id is string str)
            ArgumentException.ThrowIfNullOrEmpty(str, "Id Is null or empty");

        var eId = ParseId(id!);
        var entity = await DataProvider.FindByIdAsync(eId, cancellationToken, isQuickFind);
        return MapToDTO(entity);
    }

    public Task AddAsync(TDto? dto, CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.AddAsync(entity, cancellationToken);
    }

    public Task AddRangeAsync(IEnumerable<TDto> dtos, CancellationToken cancellationToken = default)
    {
        var entities = MapToEntities(dtos);
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));
        return DataProvider.AddRangeAsync(entities, cancellationToken);
    }

    public Task AddRangeAsync(CancellationToken cancellationToken = default, params TDto[] dtos)
    {
        var entities = MapToEntities(dtos);
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));
        return DataProvider.AddRangeAsync(cancellationToken, entities);
    }

    public Task UpdateAsync(TDto? dto, CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.UpdateAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(TDto dto, CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.DeleteAsync(entity, cancellationToken);
    }

    public Task DeleteByIdAsync(TDId? id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        var dId = ParseId(id);
        return DataProvider.DeleteByIdAsync(dId, cancellationToken);
    }

    public Task DeleteRangeAsync(IEnumerable<TDto> dtos, CancellationToken cancellationToken = default)
    {
        var entities = MapToEntities(dtos);
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));
        return DataProvider.DeleteRangeAsync(entities, cancellationToken);
    }
    #endregion
}

public abstract class ServiceProviderBase<TDto, TEntity>(IDataProviderBase<TEntity, string> dataProvider, IMapper mapper) 
    : ServiceProviderBase<TDto, string, TEntity, string, IDataProviderBase<TEntity, string>>(dataProvider, mapper)
    where TDto : class, Application.IDataObject<string> 
    where TEntity : class, Domain.IEntity<string>
{
}