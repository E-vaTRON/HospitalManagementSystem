using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserValidator : IUserValidator<CoreUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<CoreUser> manager, CoreUser user)
    {
        return Task.FromResult(IdentityResult.Success);
    }
}
