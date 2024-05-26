namespace IdentitySystem.Application;

public interface IRoleContractBase<TOutputRole, TInputRole, TKey>
    where TOutputRole : class
    where TInputRole : class
    where TKey : IEquatable<TKey>
{
    #region [ Methods ]
    #region [ Set ]
    Task<IdentityResult> SetRoleNameAsync(TInputRole role, string roleName);
    #endregion

    #region [ Create ]
    Task<IdentityResult> CreateAsync(TInputRole role);
    #endregion

    #region [ Check ]
    Task<bool> RoleExistsAsync(string roleName);
    #endregion

    #region [ Read ]
    IQueryable<TOutputRole> FindAll(Expression<Func<TInputRole, bool>>? predicate = null);

    Task<IReadOnlyCollection<TOutputRole>> FindByMultipleGuidsAsync(TKey[] userIds);

    Task<TOutputRole?> FindByIdAsync(TKey roleId);

    Task<TOutputRole?> FindByNameAsync(string normalizedRoleName);
    #endregion

    #region [ Update ]
    Task<IdentityResult> UpdateAsync(TInputRole role);
    #endregion

    #region [ Delete ]
    Task<IdentityResult> DeleteAsync(TInputRole role);
    #endregion

    #region [ Claim ]
    Task<IList<Claim>> GetClaimsAsync(TInputRole role);

    Task<IdentityResult> AddClaimAsync(TInputRole role, Claim claim);

    Task<IdentityResult> RemoveClaimAsync(TInputRole role, Claim claim);
    #endregion
    #endregion
}
