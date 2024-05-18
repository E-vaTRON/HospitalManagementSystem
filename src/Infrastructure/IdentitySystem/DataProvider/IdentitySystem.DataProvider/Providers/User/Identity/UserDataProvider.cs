using System.Data.Common;
using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserDataProvider : IUserDataProvider
{
    #region [ Field ]
    private readonly IUserManagerProvider UserManagerProvider;
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public UserDataProvider(IUserManagerProvider userManagerProvider, IdentitySystemDbContext dbContext)
    {
        UserManagerProvider = userManagerProvider;
        DbContext = dbContext;
    }
    #endregion

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        await DbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        var transaction = DbContext.Database.CurrentTransaction;
        if (transaction != null)
        {
            await transaction.CommitAsync(cancellationToken);
        }
    }

    public IQueryable<CoreUser> FindAll(Expression<Func<CoreUser, bool>>? predicate = null)
    {
        return UserManagerProvider.FindAll(predicate);
    }

    public Task<CoreUser?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return UserManagerProvider.FindByEmailAsync(email, cancellationToken);
    }

    public Task<CoreUser?> FindByGuidAsync(string id, CancellationToken cancellationToken = default)
    {
        return UserManagerProvider.FindByGuidAsync(id, cancellationToken);
    }

    public Task<IReadOnlyCollection<CoreUser>> FindByMultipleGuidsAsync(string[] userIds, CancellationToken cancellationToken = default)
    {
        return UserManagerProvider.FindByMultipleGuidsAsync(userIds, cancellationToken);
    }

    public Task<CoreUser?> FindByNameAsync(string userName)
    {
        return UserManagerProvider.FindByNameAsync(userName);
    }

    public Task<CoreUser?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        return UserManagerProvider.FindByPhoneNumberAsync(phoneNumber, cancellationToken);
    }

    public async Task<IdentityResult> CreateAsync(CoreUser user, string password)
    {
        return await UserManagerProvider.CreateAsync(user, password);
    }

    public async Task<IdentityResult> CreateAsync(CoreUser user)
    {
        return await UserManagerProvider.CreateAsync(user);
    }

    public async Task<IdentityResult> UpdateAsync(CoreUser user)
    {
        return await UserManagerProvider.UpdateAsync(user);
    }
}