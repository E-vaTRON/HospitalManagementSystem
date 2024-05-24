namespace IdentitySystem.Application;

public interface IRoleContractBase<TRole, TKey>
    where TRole : class
    where TKey : IEquatable<TKey>
{
    #region [ Methods ]
    #region [ Set ]
    Task<IdentityResult> SetRoleNameAsync(TRole role, string roleName);
    #endregion

    #region [ Create ]
    Task<IdentityResult> CreateAsync(TRole role);
    #endregion

    #region [ Check ]
    Task<bool> RoleExistsAsync(string roleName);
    #endregion

    #region [ Read ]
    IQueryable<TRole> FindAll(Expression<Func<TRole, bool>>? predicate = null);

    Task<IReadOnlyCollection<TRole>> FindByMultipleGuidsAsync(TKey[] userIds);

    Task<TRole?> FindByIdAsync(TKey roleId);

    Task<TRole?> FindByNameAsync(string normalizedRoleName);
    #endregion

    #region [ Update ]
    Task<IdentityResult> UpdateAsync(TRole role);
    #endregion

    #region [ Delete ]
    Task<IdentityResult> DeleteAsync(TRole role);
    #endregion

    #region [ Role Claim ]
    Task<IList<Claim>> GetClaimsAsync(TRole role);

    Task<IdentityResult> AddClaimAsync(TRole role, Claim claim);

    Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim);
    #endregion
    #endregion
}
