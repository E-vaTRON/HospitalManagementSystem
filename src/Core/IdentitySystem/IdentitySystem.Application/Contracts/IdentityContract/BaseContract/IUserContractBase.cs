namespace IdentitySystem.Application;

public interface IUserContractBase<TUser, TKey>
    where TUser : class
    where TKey : IEquatable<TKey>
{
    Task<TUser?> FindByGuidAsync(TKey guid, CancellationToken cancellationToken = default!);

    Task<IReadOnlyCollection<TUser>> FindByMultipleGuidsAsync(TKey[] userGuids, CancellationToken cancellationToken = default);

    Task<TUser?> FindByNameAsync(string userName);

    Task<TUser?> FindByEmailAsync(string email, CancellationToken cancellationToken = default!);

    Task<TUser?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default!);

    IQueryable<TUser> FindAll(Expression<Func<TUser, bool>>? predicate = null);

    Task<IdentityResult> CreateAsync(TUser user, string password);

    Task<IdentityResult> CreateAsync(TUser user);

    Task<IdentityResult> UpdateAsync(TUser user);
}
