namespace IdentitySystem.ServiceProvider;

public class UserServiceBase<TDto, TDId, TEntity, TEId>
    where TDto : class, Application.IDataObject<TDId>
    where TEntity : IdentityUser<TEId>
    where TEId : IEquatable<TEId>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }
    #endregion

    #region [ CTor ]
    public UserServiceBase(IMapper mapper)
    {
        Mapper = mapper;
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
}

public abstract class UserServiceBase<TDto, TEntity>( IMapper mapper)
    : UserServiceBase<TDto, string, TEntity, string>(mapper)
    where TDto : class, Application.IDataObject<string>
    where TEntity : IdentityUser<string>
{
}
