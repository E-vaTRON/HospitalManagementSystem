using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;

namespace IdentitySystem.DataProvider;

public class UserRoleDataProvider : IUserRoleDataProvider
{
    #region [ Field ]
    private readonly IUserRoleManagerProvider UserRoleManagerProvider;
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public UserRoleDataProvider(IUserRoleManagerProvider userRoleManagerProvider, IdentitySystemDbContext dbContext)
    {
        UserRoleManagerProvider = userRoleManagerProvider;
        DbContext = dbContext;
    }
    #endregion
}