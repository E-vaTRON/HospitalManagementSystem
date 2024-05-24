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
    public IQueryable<CoreUser> FindAll(Expression<Func<CoreUser, bool>>? predicate = null)
        => Users.Where(u => !u.IsDeleted)
                .WhereIf(predicate != null, predicate!);

    public async Task<IReadOnlyCollection<CoreUser>> FindByMultipleGuidsAsync(string[] userIds)
    {
        var userGuidsSet = new HashSet<string>(userIds);
        var users = await Users.Where(u => userGuidsSet.Contains(u.Id)).ToListAsync(CancellationToken);
        return users.ToList().AsReadOnly();
    }

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
}
