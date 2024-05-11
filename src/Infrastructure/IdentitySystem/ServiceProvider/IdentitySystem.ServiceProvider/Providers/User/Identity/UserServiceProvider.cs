using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.ServiceProvider;

public class UserServiceProvider : IUserServiceProvider
{
    #region [ Field ]
    private readonly IUserDataProvider DataProvider;
    #endregion

    #region [ CTor ]
    public UserServiceProvider(IUserDataProvider dataProvider)
    {
        DataProvider = dataProvider;
    }

    public Task<SignInResult> CheckPasswordSignInAsync(Domain.User user, string password, LoginMode mode, bool lockoutOnFailure, CancellationToken cancellationToken = default)
    {
        return DataProvider.CheckPasswordSignInAsync(user, password, mode, lockoutOnFailure, cancellationToken);
    }

    public IQueryable<Domain.User> FindAll(Expression<Func<Domain.User, bool>>? predicate = null)
    {
        return DataProvider.FindAll(predicate);
    }

    public Task<Domain.User?> FindByGuidAsync(string guid, CancellationToken cancellationToken = default)
    {
        return DataProvider.FindByGuidAsync(guid, cancellationToken);
    }

    public Task<IReadOnlyCollection<Domain.User>> FindByMultipleGuidsAsync(string[] userGuids, CancellationToken cancellationToken = default)
    {
        return DataProvider.FindByMultipleGuidsAsync(userGuids, cancellationToken);
    }

    public Task<Domain.User?> FindByNameAsync(string userName)
    {
        return DataProvider.FindByNameAsync(userName);
    }

    public Task<Domain.User?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        return DataProvider.FindByPhoneNumberAsync(phoneNumber, cancellationToken);
    }

    public Task<IdentityResult> CreateAsync(Domain.User user, string password)
    {
        return DataProvider.CreateAsync(user, password);
    }


    public Task<IdentityResult> UpdateAsync(Domain.User user)
    {
        return DataProvider.UpdateAsync(user);
    }
    #endregion
}
