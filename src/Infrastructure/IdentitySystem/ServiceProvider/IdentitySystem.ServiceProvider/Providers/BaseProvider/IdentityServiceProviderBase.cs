namespace IdentitySystem.ServiceProvider;

public abstract class IdentityServiceProviderBase<TOutputDto, TInputDto, TDId, TEntity, TEId, TDataProvider> : IIdentityServiceProviderBase<TOutputDto, TInputDto, TDId>
    where TOutputDto : class, Application.IDataObject<TDId>
    where TInputDto : class, Application.IDataObject<TDId>
    where TEntity : class
    where TDataProvider : IIdentityDataProviderBase<TEntity, TEId>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }
    protected virtual TDataProvider DataProvider { get; set; }
    #endregion

    #region [ CTor ]
    public IdentityServiceProviderBase(TDataProvider dataProvider, IMapper mapper)
    {
        Mapper = mapper;
        DataProvider = dataProvider;
    }
    #endregion

    #region [ Interna - Method ]
    #region [ Mapping ]
    protected virtual TEId ParseId(TDId id)
        => Mapper.Map<TEId>(id);

    protected virtual TEId[] ParseIds(TDId[] ids)
        => Mapper.Map<TEId[]>(ids);

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

    #region [ Public - Method ]
    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(TInputDto dto)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return await DataProvider.CreateAsync(entity);
    }
    #endregion

    #region [ Read ]
    public IQueryable<TOutputDto> FindAll(Expression<Func<TInputDto, bool>>? dtoPredicate = null)
    {
        var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
        var entities = DataProvider.FindAll(entityPredicate);
        return MapToDTOs(entities).AsQueryable();
    }

    public async Task<IReadOnlyCollection<TOutputDto>> FindByMultipleGuidsAsync(TDId[] ids)
    {
        var eIds = ParseIds(ids);
        var entities = await DataProvider.FindByMultipleGuidsAsync(eIds);
        return MapToDTOs(entities).ToList().AsReadOnly();
    }

    public async Task<TOutputDto?> FindByIdAsync(TDId id)
    {
        var eId = ParseId(id);
        ArgumentNullException.ThrowIfNull(eId, nameof(eId));
        var entity = await DataProvider.FindByIdAsync(eId);
        return MapToDTO(entity);
    }

    public async Task<TOutputDto?> FindByNameAsync(string normalizedName)
    {
        ArgumentNullException.ThrowIfNull(normalizedName, nameof(normalizedName));
        var entity = await DataProvider.FindByNameAsync(normalizedName);
        return MapToDTO(entity);
    }
    #endregion

    #region [ Update ]
    public async Task<IdentityResult> UpdateAsync(TInputDto dto)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return await DataProvider.UpdateAsync(entity);
    }
    #endregion

    #region [ Delete ]
    public async Task<IdentityResult> DeleteAsync(TInputDto dto)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return await DataProvider.DeleteAsync(entity);
    }
    #endregion

    #region [ Claim ]
    public async Task<IList<Claim>> GetClaimsAsync(TInputDto dto)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return await DataProvider.GetClaimsAsync(entity);
    }

    public async Task<IdentityResult> AddClaimAsync(TInputDto dto, Claim claim)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return await DataProvider.AddClaimAsync(entity, claim);
    }

    public async Task<IdentityResult> RemoveClaimAsync(TInputDto dto, Claim claim)
    {
        var entity = MapToEntity(dto);
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        return await DataProvider.RemoveClaimAsync(entity, claim);
    }
    #endregion
    #endregion
}

public abstract class IdentityServiceProviderBase<TOutputDto, TInputDto, TEntity>(IIdentityDataProviderBase<TEntity, string> dataProvider, IMapper mapper) 
    : IdentityServiceProviderBase<TOutputDto, TInputDto, string, TEntity, string, IIdentityDataProviderBase<TEntity, string>>(dataProvider, mapper)
    where TOutputDto : class, Application.IDataObject<string>
    where TInputDto : class, Application.IDataObject<string>
    where TEntity : class
{
}