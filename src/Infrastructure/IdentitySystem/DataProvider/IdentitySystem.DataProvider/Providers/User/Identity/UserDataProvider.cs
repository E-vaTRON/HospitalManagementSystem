using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserDataProvider : UserManager<CoreUser>, IUserDataProvider
{
    public UserDataProvider( UserStoreProvider store, 
                             IOptions<IdentityOptions> optionsAccessor, 
                             IPasswordHasher<CoreUser> passwordHasher, 
                             IEnumerable<IUserValidator<CoreUser>> userValidators, 
                             IEnumerable<IPasswordValidator<CoreUser>> passwordValidators, 
                             ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
                             IServiceProvider services, ILogger<UserManager<CoreUser>> logger ) 
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }

    public Task<SignInResult> CheckPasswordSignInAsync(CoreUser user, string password, LoginMode mode, bool lockoutOnFailure, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<CoreUser> FindAll(Expression<Func<CoreUser, bool>>? predicate = null)
        => Users.Where(u => !u.IsDeleted)
                .WhereIf(predicate != null, predicate!);

    public async Task<CoreUser?> FindByGuidAsync(string guid, CancellationToken cancellationToken = default)
        => await Users.FirstOrDefaultAsync(u => u.Id == guid, cancellationToken);

    public Task<IReadOnlyCollection<CoreUser>> FindByMultipleGuidsAsync(string[] userGuids, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<CoreUser?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
        => await Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);

    public new async Task<CoreUser?> FindByNameAsync(string userName)
    {
        var user = await base.FindByNameAsync(userName);
        return (user is null || user.IsDeleted) ? null : user;
    }

    public async Task<CoreUser?> FindByEmailAsync(string email, CancellationToken cancellationToken = default!)
        => await Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public async Task<List<CoreUser>> FindByGuidsAsync(string[] userGuids, CancellationToken cancellationToken = default!)
        => await Users.Where(u => userGuids.Contains(u.Id)).ToListAsync(cancellationToken);
}