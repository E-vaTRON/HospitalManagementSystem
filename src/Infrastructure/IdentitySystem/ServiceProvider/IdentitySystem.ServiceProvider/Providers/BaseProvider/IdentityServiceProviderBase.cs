namespace IdentitySystem.ServiceProvider;

public class IdentityServiceProviderBase<TDto, TDId, TEntity, TEId>
    where TDto : class, Application.IDataObject<TDId>
    where TEntity : class
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }
    #endregion

    #region [ CTor ]
    public IdentityServiceProviderBase(IMapper mapper)
    {
        Mapper = mapper;
    }
    #endregion

    #region [ Interna - Method ]
    #region [ Mapping ]
    //protected virtual TEId ParseId(TDId id)
    //    => Mapper.Map<TEId>(id);

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

    #region [ Public - Method ]
    #endregion
}

public class IdentityServiceProviderBase<TDto, TEntity>(IMapper mapper) 
    : IdentityServiceProviderBase<TDto, string, TEntity, string>(mapper)
    where TDto : class, Application.IDataObject<string>
    where TEntity : class
{
}