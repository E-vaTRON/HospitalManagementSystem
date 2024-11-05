namespace IdentitySystem.ServiceProvider;

public abstract class ServiceProviderBase<TOutputDto, TInputDto, TDId, TEntity, TEId, TDataProvider> : IServiceProviderBase<TOutputDto, TInputDto, TDId>
    where TOutputDto : class, Application.IDataObject<TDId>
    where TInputDto : class, Application.IDataObject<TDId>
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
        this.Mapper = mapper;
        this.DataProvider = dataProvider;
    }
    #endregion

    #region [ Internal Method ]
    #region [ Mapping ]
    protected virtual TEId ParseId(TDId id)
        => Mapper.Map<TEId>(id);

    [DebuggerStepThrough]
    protected virtual TEntity? MapToEntity(TInputDto? dto)
        => Mapper.Map<TEntity?>(dto);

    [DebuggerStepThrough]
    protected virtual TOutputDto? MapToDTO(TEntity? dbEntity)
        => Mapper.Map<TOutputDto?>(dbEntity);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TEntity> MapToEntities(IEnumerable<TInputDto?> dtos)
        => Mapper.Map<IEnumerable<TEntity>>(dtos);

    [DebuggerStepThrough]
    protected virtual TEntity[] MapToEntities(params TInputDto[] dtos)
        => Mapper.Map<TEntity[]>(dtos);

    [DebuggerStepThrough]
    protected virtual IEnumerable<TOutputDto> MapToDTOs(IEnumerable<TEntity?> entities)
        => Mapper.Map<IEnumerable<TOutputDto>>(entities);

    [DebuggerStepThrough]
    protected virtual Expression<Func<TEntity, bool>> MapToEntityPredicate(Expression<Func<TInputDto, bool>>? dtoPredicate)
        => Mapper.Map<Expression<Func<TEntity, bool>>>(dtoPredicate);
    #endregion

    #endregion

    #region [ Public Method ]
    public virtual async Task<IEnumerable<TOutputDto>> FindAllWithPredicateAsync(Expression<Func<TInputDto, bool>>? dtoPredicate = null, CancellationToken cancellationToken = default)
    {
        var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
        var entities = await DataProvider.FindAllWithPredicateAsync(entityPredicate, cancellationToken);
        return MapToDTOs(entities);
    }

    public async Task<IEnumerable<TOutputDto>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await DataProvider.FindAllAsync(cancellationToken);
        return MapToDTOs(entities);
    }

    public virtual async Task<TOutputDto?> FindByIdAsync(TDId? id, CancellationToken cancellationToken = default, bool isQuickFind = true)
    {
        if (id == null)
            ArgumentNullException.ThrowIfNull(id, "Id Is null");
        if (id is string str)
            ArgumentException.ThrowIfNullOrEmpty(str, "Id Is null or empty");

        var eId = ParseId(id!);
        var entity = await DataProvider.FindByIdAsync(eId, cancellationToken, isQuickFind);
        return MapToDTO(entity);
    }

    public Task AddAsync(TInputDto? dto, CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.AddAsync(entity, cancellationToken);
    }

    public Task AddRangeAsync(IEnumerable<TInputDto> dtos, CancellationToken cancellationToken = default)
    {
        var entities = MapToEntities(dtos);
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));
        return DataProvider.AddRangeAsync(entities, cancellationToken);
    }

    public Task AddRangeAsync(CancellationToken cancellationToken = default, params TInputDto[] dtos)
    {
        var entities = MapToEntities(dtos);
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));
        return DataProvider.AddRangeAsync(cancellationToken, entities);
    }

    public Task UpdateAsync(TInputDto? dto, CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return DataProvider.UpdateAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(TInputDto dto, CancellationToken cancellationToken = default)
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

    public Task DeleteRangeAsync(IEnumerable<TInputDto> dtos, CancellationToken cancellationToken = default)
    {
        var entities = MapToEntities(dtos);
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));
        return DataProvider.DeleteRangeAsync(entities, cancellationToken);
    }
    #endregion
}

public abstract class ServiceProviderBase<TOutputDto, TInputDto, TEntity>(IDataProviderBase<TEntity, string> dataProvider, IMapper mapper) 
    : ServiceProviderBase<TOutputDto, TInputDto, string, TEntity, string, IDataProviderBase<TEntity, string>>(dataProvider, mapper)
    where TOutputDto : class, Application.IDataObject<string>
    where TInputDto : class, Application.IDataObject<string>
    where TEntity : class, Domain.IEntity<string>
{
}

public abstract class ServiceProviderIntBase<TOutputDto, TInputDto, TEntity>(IDataProviderBase<TEntity, int> dataProvider, IMapper mapper)
    : ServiceProviderBase<TOutputDto, TInputDto, int, TEntity, int, IDataProviderBase<TEntity, int>>(dataProvider, mapper)
    where TOutputDto : class, Application.IDataObject<int>
    where TInputDto : class, Application.IDataObject<int>
    where TEntity : class, Domain.IEntity<int>
{
}