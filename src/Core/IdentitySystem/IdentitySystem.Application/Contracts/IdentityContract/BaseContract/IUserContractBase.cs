namespace IdentitySystem.Application;

public interface IUserContractBase<TUser, TKey>
    where TUser : class
    where TKey : IEquatable<TKey>
{
    #region [ Set ]
    Task<IdentityResult> SetUserNameAsync(TUser user, string userName);
    #endregion

    #region [ Create ]
    Task<IdentityResult> CreateAsync(TUser user, string password);

    Task<IdentityResult> CreateAsync(TUser user);
    #endregion

    #region [ Read ]
    IQueryable<TUser> FindAll(Expression<Func<TUser, bool>>? predicate = null);

    Task<IReadOnlyCollection<TUser>> FindByMultipleGuidsAsync(TKey[] userIds);

    Task<TUser?> FindByIdAsync(TKey userId);

    Task<TUser?> FindByEmailAsync(string normalizedEmail);

    Task<TUser?> FindByPhoneNumberAsync(string phoneNumber);

    Task<TUser?> FindByNameAsync(string normalizedUserName);
    #endregion

    #region [ Update ]
    Task<IdentityResult> UpdateAsync(TUser user);
    #endregion

    #region [ Delete ]
    Task<IdentityResult> DeleteAsync(TUser user);
    #endregion

    #region [ Role ]
    Task<IList<string>> GetRolesAsync(TUser user);

    Task<IdentityResult> AddToRoleAsync(TUser user, string roleNormalizedName);

    Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role);
    #endregion

    #region [ Claim ]
    Task<IList<Claim>> GetClaimsAsync(TUser user);

    Task<IdentityResult> AddClaimAsync(TUser user, Claim claim);

    Task<IdentityResult> RemoveClaimAsync(TUser user, Claim claim);
    #endregion

    #region [ Password ]
    Task<bool> HasPasswordAsync(TUser user);

    Task<bool> CheckPasswordAsync(TUser user, string password);

    Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);
    #endregion
}
