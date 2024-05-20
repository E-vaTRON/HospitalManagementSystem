using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleDataProvider : IRoleDataProvider
{
    #region [ Field ]
    private readonly IRoleManagerProvider RoleManagerProvider;
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public RoleDataProvider(IRoleManagerProvider roleManagerProvider, IdentitySystemDbContext dbContext)
    {
        RoleManagerProvider = roleManagerProvider;
        DbContext = dbContext;
    }
    #endregion
}