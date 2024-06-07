namespace IdentitySystem.DataProvider;

public abstract class IdentityDataProviderBase<TEntity, TEId, TModel, TMId, TManagerProvider> : IIdentityDataProviderBase<TEntity, TEId>
    where TEntity : class
    where TModel : class
    where TManagerProvider : IIdentityManagerProviderBase<TEntity, TEId>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public TManagerProvider ManagerProvider { get; protected set; }

    //public IdentitySystemDbContext DbContext { get; protected set; }

    //public DbSet<TModel> DbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public IdentityDataProviderBase(TManagerProvider managerProvider, IMapper mapper)
    {
        //DbContext = context;
        Mapper = mapper;

        //DbSet = DbContext.Set<TModel>();
        ManagerProvider = managerProvider;
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
    #endregion
    #endregion

    #region [ Public Method ]
    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(TEntity entity)
        => await ManagerProvider.CreateAsync(entity);
    #endregion

    #region [ Read ]
    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null)
        => ManagerProvider.FindAll(predicate);

    public async Task<IReadOnlyCollection<TEntity>> FindByMultipleGuidsAsync(TEId[] ids)
        => await ManagerProvider.FindByMultipleGuidsAsync(ids);

    public async Task<TEntity?> FindByIdAsync(TEId id)
        => await ManagerProvider.FindByIdAsync(id);

    public async Task<TEntity?> FindByNameAsync(string normalizedName)
        => await ManagerProvider.FindByNameAsync(normalizedName);
    #endregion

    #region [ Update ]
    public async Task<IdentityResult> UpdateAsync(TEntity entity)
        => await ManagerProvider.UpdateAsync(entity);

    #endregion

    #region [ Delete ]
    public async Task<IdentityResult> DeleteAsync(TEntity entity)
        => await ManagerProvider.DeleteAsync(entity);
    #endregion

    #region [ Claim ]
    public async Task<IList<Claim>> GetClaimsAsync(TEntity entity)
        => await ManagerProvider.GetClaimsAsync(entity);

    public async Task<IdentityResult> AddClaimAsync(TEntity entity, Claim claim)
        => await ManagerProvider.AddClaimAsync(entity, claim);

    public async Task<IdentityResult> RemoveClaimAsync(TEntity entity, Claim claim)
        => await ManagerProvider.RemoveClaimAsync(entity, claim);
    #endregion
    #endregion
}

public abstract class IdentityDataProviderBase<TEntity, TModel>(IIdentityManagerProviderBase<TEntity, string> managerProvider, IMapper mapper)
    : IdentityDataProviderBase<TEntity, string, TModel, Guid, IIdentityManagerProviderBase<TEntity, string>>(managerProvider, mapper)
    where TEntity : class
    where TModel : class
{ 
}

public abstract class IdentityDataProviderIntBase<TEntity, TModel>(IIdentityManagerProviderBase<TEntity, int> managerProvider, IMapper mapper)
    : IdentityDataProviderBase<TEntity, int, TModel, int, IIdentityManagerProviderBase<TEntity, int>>(managerProvider, mapper)
    where TEntity : class
    where TModel : class
{
}