namespace IdentitySystem.Application;

public class UserManagerProvider : UserManager<User>
{
    #region [ CTor ]
    public UserManagerProvider( IUserStore<User> store,
                                IOptions<IdentityOptions> optionsAccessor,
                                IPasswordHasher<User> passwordHasher,
                                IEnumerable<IUserValidator<User>> userValidators,
                                IEnumerable<IPasswordValidator<User>> passwordValidators,
                                ILookupNormalizer keyNormalizer,
                                IdentityErrorDescriber errors,
                                IServiceProvider services,
                                ILogger<UserManager<User>> logger) 
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }
    #endregion

    //public async Task<User?> FindByGuidAsync(string guid, CancellationToken cancellationToken = default!)
    //    => await Users.FirstOrDefaultAsync(u => u.Id == guid, cancellationToken);

    //public new async Task<User?> FindByNameAsync(string userName)
    //{
    //    var user = await base.FindByNameAsync(userName);
    //    return (user is null || user.IsDeleted) ? null : user;
    //}

    //public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default!)
    //    => await Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    //public async Task<User?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default!)
    //    => await Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);

    //public IQueryable<User> FindAll(Expression<Func<User, bool>>? predicate = null)
    //    => Users
    //        .Where(u => !u.IsDeleted)
    //        .WhereIf(predicate != null, predicate!);

    //public async Task<List<User>> FindByGuidsAsync(string[] userGuids, CancellationToken cancellationToken = default!)
    //    => await Users.Where(u => userGuids.Contains(u.Id)).ToListAsync(cancellationToken);
}