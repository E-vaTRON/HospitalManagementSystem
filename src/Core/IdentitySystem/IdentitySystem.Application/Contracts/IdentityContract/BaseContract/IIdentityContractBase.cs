namespace IdentitySystem.Application;

public interface IIdentityContractBase<TOutputEntity, TInputEntity, TKey>
    where TOutputEntity : class
    where TInputEntity : class
{
    #region [ Create ]
    Task<IdentityResult> CreateAsync(TInputEntity entity);
    #endregion

    #region [ Read ]
    IQueryable<TOutputEntity> FindAll(Expression<Func<TInputEntity, bool>>? predicate = null);

    Task<IReadOnlyCollection<TOutputEntity>> FindByMultipleGuidsAsync(TKey[] ids);

    Task<TOutputEntity?> FindByIdAsync(TKey id);

    Task<TOutputEntity?> FindByNameAsync(string normalizedName);
    #endregion

    #region [ Update ]
    Task<IdentityResult> UpdateAsync(TInputEntity entity);
    #endregion

    #region [ Delete ]
    Task<IdentityResult> DeleteAsync(TInputEntity entity);
    #endregion

    #region [ Claim ]
    Task<IList<Claim>> GetClaimsAsync(TInputEntity entity);

    Task<IdentityResult> AddClaimAsync(TInputEntity entity, Claim claim);

    Task<IdentityResult> RemoveClaimAsync(TInputEntity entity, Claim claim);
    #endregion
}
