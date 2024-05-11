namespace IdentitySystem.Application;

public interface IUserManagerProvider<TUser, TKey>
    where TUser : IdentityUser<TKey>
    where TKey : IEquatable<TKey>
{
    Task<TUser?> FindByGuidAsync(TKey guid, CancellationToken cancellationToken = default!);

    Task<IReadOnlyCollection<TUser>> FindByMultipleGuidsAsync(TKey[] userGuids, CancellationToken cancellationToken = default);

    Task<TUser?> FindByNameAsync(string userName);

    Task<TUser?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default!);

    Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, LoginMode mode,
                                                bool lockoutOnFailure, CancellationToken cancellationToken = default!);
    IQueryable<TUser> FindAll(Expression<Func<TUser, bool>>? predicate = null);

    Task<IdentityResult> CreateAsync(TUser user, string password);
    Task<IdentityResult> UpdateAsync(TUser user);
}