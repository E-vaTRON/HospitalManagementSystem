using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserDataProvider : IdentityDataProviderBase<CoreUser, DataUser>, IUserDataProvider
{
    #region [ Field ]
    private readonly IUserManagerProvider UserManagerProvider;
    #endregion

    #region [ CTor ]
    public UserDataProvider(IUserManagerProvider userManagerProvider, IMapper mapper) 
        : base(userManagerProvider, mapper)
    {
        UserManagerProvider = userManagerProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Set ]
    public Task<IdentityResult> SetUserNameAsync(CoreUser user, string userName)
        => UserManagerProvider.SetUserNameAsync(user, userName);
    #endregion

    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(CoreUser user, string password)
        => await UserManagerProvider.CreateAsync(user, password);

    //public async Task<IdentityResult> CreateAsync(CoreUser user)
    //    => await UserManagerProvider.CreateAsync(user);
    #endregion

    #region [ Read ]
    //public IQueryable<CoreUser> FindAll(Expression<Func<CoreUser, bool>>? predicate = null)
    //    => UserManagerProvider.FindAll(predicate);

    //public async Task<IReadOnlyCollection<CoreUser>> FindByMultipleGuidsAsync(string[] userIds)
    //    => await UserManagerProvider.FindByMultipleGuidsAsync(userIds);

    //public async Task<CoreUser?> FindByIdAsync(string userId)
    //    => await UserManagerProvider.FindByIdAsync(userId);

    public async Task<CoreUser?> FindByEmailAsync(string normalizedEmail)
        => await UserManagerProvider.FindByEmailAsync(normalizedEmail);

    public async Task<CoreUser?> FindByPhoneNumberAsync(string phoneNumber)
        => await UserManagerProvider.FindByPhoneNumberAsync(phoneNumber);

    //public async Task<CoreUser?> FindByNameAsync(string normalizedUserName)
    //    => await UserManagerProvider.FindByNameAsync(normalizedUserName);
    #endregion

    #region [ Update ]
    //public async Task<IdentityResult> UpdateAsync(CoreUser user)
    //    => await UserManagerProvider.UpdateAsync(user);
    #endregion

    #region [ Delete ]
    //public async Task<IdentityResult> DeleteAsync(CoreUser user)
    //    => await UserManagerProvider.DeleteAsync(user);
    #endregion

    #region [ Role ]
    public async Task<IList<string>> GetRolesAsync(CoreUser user)
        => await UserManagerProvider.GetRolesAsync(user);

    public async Task<IList<CoreUser>> GetUsersInRoleAsync(string roleNormalizedName)
        => await UserManagerProvider.GetUsersInRoleAsync(roleNormalizedName);

    public async Task<IdentityResult> AddToRoleAsync(CoreUser user, string roleNormalizedName)
        => await UserManagerProvider.AddToRoleAsync(user, roleNormalizedName);

    public async Task<IdentityResult> RemoveFromRoleAsync(CoreUser user, string roleNormalizedName)
        => await UserManagerProvider.RemoveFromRoleAsync(user, roleNormalizedName);
    #endregion

    #region [ Claim ]
    //public async Task<IList<Claim>> GetClaimsAsync(CoreUser user)
    //    => await UserManagerProvider.GetClaimsAsync(user);

    //public async Task<IdentityResult> AddClaimAsync(CoreUser user, Claim claim)
    //    => await UserManagerProvider.AddClaimAsync(user, claim);

    //public async Task<IdentityResult> RemoveClaimAsync(CoreUser user, Claim claim)
    //    => await UserManagerProvider.RemoveClaimAsync(user, claim);
    #endregion

    #region [ Password ]
    public async Task<string> GeneratePasswordResetTokenAsync(CoreUser user)
        => await UserManagerProvider.GeneratePasswordResetTokenAsync(user);

    public async Task<bool> HasPasswordAsync(CoreUser user)
        => await UserManagerProvider.HasPasswordAsync(user);

    public async Task<bool> CheckPasswordAsync(CoreUser user, string password)
        => await UserManagerProvider.CheckPasswordAsync(user, password);

    public async Task<IdentityResult> ChangePasswordAsync(CoreUser user, string currentPassword, string newPassword)
        => await UserManagerProvider.ChangePasswordAsync(user, currentPassword, newPassword);

    public async Task<IdentityResult> ResetPasswordAsync(CoreUser user, string token, string newPassword)
        => await UserManagerProvider.ResetPasswordAsync(user, token, newPassword);
    #endregion
    #endregion
}