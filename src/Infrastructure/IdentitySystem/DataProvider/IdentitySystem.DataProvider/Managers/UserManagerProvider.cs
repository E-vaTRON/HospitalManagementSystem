using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserManagerProvider : UserManager<CoreUser>, IUserManagerProvider
{
    #region [ Field ]
    protected readonly IServiceProvider Services;
    #endregion

    #region [ CTor ]
    public UserManagerProvider( UserStoreProvider store,
                                IOptions<IdentityOptions> optionsAccessor,
                                IPasswordHasher<CoreUser> passwordHasher,
                                IEnumerable<IUserValidator<CoreUser>> userValidators,
                                IEnumerable<IPasswordValidator<CoreUser>> passwordValidators,
                                ILookupNormalizer keyNormalizer,
                                IdentityErrorDescriber errors,
                                IServiceProvider services,
                                ILogger<UserManager<CoreUser>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        Services = services;
    }
    #endregion

    #region [ Methods ]
    //#region [ Set ]
    //public override Task<IdentityResult> SetUserNameAsync(CoreUser user, string? userName)
    //    => base.SetUserNameAsync(user, userName);
    //#endregion

    public IQueryable<CoreUser> FindAll(Expression<Func<CoreUser, bool>>? predicate = null)
        => Users.WhereIf(predicate != null, predicate!);

    public async Task<IReadOnlyCollection<CoreUser>> FindByMultipleGuidsAsync(string[] userIds)
    {
        var userGuidsSet = new HashSet<string>(userIds);
        var users = await Users.Where(u => userGuidsSet.Contains(u.Id)).ToListAsync(CancellationToken);
        return users.ToList().AsReadOnly();
    }

    #region [ Read ]
    //public async Task<CoreUser?> FindByIdAsync(string userId)
    //    => await UserManagerProvider.FindByIdAsync(userId);

    //public override async Task<CoreUser?> FindByEmailAsync(string normalizedEmail)
    //{
    //    base.Options.Stores.ProtectPersonalData = true;
    //    var user = await base.FindByEmailAsync(normalizedEmail);
    //    return user;
    //}

    //public async Task<CoreUser?> FindByNameAsync(string normalizedUserName)
    //    => await UserManagerProvider.FindByNameAsync(normalizedUserName);
    #endregion

    public async Task<CoreUser?> FindByPhoneNumberAsync(string phoneNumber)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(phoneNumber, nameof(phoneNumber));

        var user = new CoreUser();
        if (Store is UserStoreProvider storeProvider)
        {
            user = await storeProvider.FindByPhoneNumberAsync(phoneNumber, CancellationToken).ConfigureAwait(false);

            if (user == null && Options.Stores.ProtectPersonalData)
            {
                var keyRing = Services.GetService<ILookupProtectorKeyRing>();
                var protector = Services.GetService<ILookupProtector>();
                if (keyRing != null && protector != null)
                {
                    foreach (var key in keyRing.GetAllKeyIds())
                    {
                        var oldKey = protector.Protect(key, phoneNumber);
                        user = await storeProvider.FindByPhoneNumberAsync(oldKey, CancellationToken).ConfigureAwait(false);
                        if (user != null)
                        {
                            return user;
                        }
                    }
                }
            }
            return user;
        }
        return user;
    }
    #endregion

    //#region [ Methods ]


    //#region [ Create ]
    //public async Task<IdentityResult> CreateAsync(CoreUser user, string password)
    //    => await UserManagerProvider.CreateAsync(user, password);

    ////public async Task<IdentityResult> CreateAsync(CoreUser user)
    ////    => await UserManagerProvider.CreateAsync(user);
    //#endregion

    //#region [ Update ]
    ////public async Task<IdentityResult> UpdateAsync(CoreUser user)
    ////    => await UserManagerProvider.UpdateAsync(user);
    //#endregion

    //#region [ Delete ]
    ////public async Task<IdentityResult> DeleteAsync(CoreUser user)
    ////    => await UserManagerProvider.DeleteAsync(user);
    //#endregion

    //#region [ Role ]
    //public async Task<IList<string>> GetRolesAsync(CoreUser user)
    //    => await UserManagerProvider.GetRolesAsync(user);

    //public async Task<IList<CoreUser>> GetUsersInRoleAsync(string roleNormalizedName)
    //    => await UserManagerProvider.GetUsersInRoleAsync(roleNormalizedName);

    //public async Task<IdentityResult> AddToRoleAsync(CoreUser user, string roleNormalizedName)
    //    => await UserManagerProvider.AddToRoleAsync(user, roleNormalizedName);

    //public async Task<IdentityResult> RemoveFromRoleAsync(CoreUser user, string roleNormalizedName)
    //    => await UserManagerProvider.RemoveFromRoleAsync(user, roleNormalizedName);
    //#endregion

    //#region [ Claim ]
    ////public async Task<IList<Claim>> GetClaimsAsync(CoreUser user)
    ////    => await UserManagerProvider.GetClaimsAsync(user);

    ////public async Task<IdentityResult> AddClaimAsync(CoreUser user, Claim claim)
    ////    => await UserManagerProvider.AddClaimAsync(user, claim);

    ////public async Task<IdentityResult> RemoveClaimAsync(CoreUser user, Claim claim)
    ////    => await UserManagerProvider.RemoveClaimAsync(user, claim);
    //#endregion

    //#region [ Password ]
    //public async Task<string> GeneratePasswordResetTokenAsync(CoreUser user)
    //    => await UserManagerProvider.GeneratePasswordResetTokenAsync(user);

    //public async Task<bool> HasPasswordAsync(CoreUser user)
    //    => await UserManagerProvider.HasPasswordAsync(user);

    //public async Task<bool> CheckPasswordAsync(CoreUser user, string password)
    //    => await UserManagerProvider.CheckPasswordAsync(user, password);

    //public async Task<IdentityResult> ChangePasswordAsync(CoreUser user, string currentPassword, string newPassword)
    //    => await UserManagerProvider.ChangePasswordAsync(user, currentPassword, newPassword);

    //public async Task<IdentityResult> ResetPasswordAsync(CoreUser user, string token, string newPassword)
    //    => await UserManagerProvider.ResetPasswordAsync(user, token, newPassword);
    //#endregion
}
