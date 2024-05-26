namespace IdentitySystem.Application;

public interface IUserContractBase<TOutputUser, TInputUser, TKey>
    where TOutputUser : class
    where TInputUser : class
    where TKey : IEquatable<TKey>
{
    #region [ Set ]
    Task<IdentityResult> SetUserNameAsync(TInputUser user, string userName);
    #endregion

    #region [ Create ]
    Task<IdentityResult> CreateAsync(TInputUser user, string password);

    Task<IdentityResult> CreateAsync(TInputUser user);
    #endregion

    #region [ Read ]
    IQueryable<TOutputUser> FindAll(Expression<Func<TInputUser, bool>>? predicate = null);

    Task<IReadOnlyCollection<TOutputUser>> FindByMultipleGuidsAsync(TKey[] userIds);

    Task<TOutputUser?> FindByIdAsync(TKey userId);

    Task<TOutputUser?> FindByEmailAsync(string normalizedEmail);

    Task<TOutputUser?> FindByPhoneNumberAsync(string phoneNumber);

    Task<TOutputUser?> FindByNameAsync(string normalizedUserName);
    #endregion

    #region [ Update ]
    Task<IdentityResult> UpdateAsync(TInputUser user);
    #endregion

    #region [ Delete ]
    Task<IdentityResult> DeleteAsync(TInputUser user);
    #endregion

    #region [ Role ]
    Task<IList<string>> GetRolesAsync(TInputUser user);

    Task<IdentityResult> AddToRoleAsync(TInputUser user, string roleNormalizedName);

    Task<IdentityResult> RemoveFromRoleAsync(TInputUser user, string role);
    #endregion

    #region [ Claim ]
    Task<IList<Claim>> GetClaimsAsync(TInputUser user);

    Task<IdentityResult> AddClaimAsync(TInputUser user, Claim claim);

    Task<IdentityResult> RemoveClaimAsync(TInputUser user, Claim claim);
    #endregion

    #region [ Password ]
    Task<bool> HasPasswordAsync(TInputUser user);

    Task<bool> CheckPasswordAsync(TInputUser user, string password);

    Task<IdentityResult> ChangePasswordAsync(TInputUser user, string currentPassword, string newPassword);
    #endregion
}
