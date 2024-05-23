using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleDataProvider : IRoleDataProvider
{
    #region [ Field ]
    private readonly IRoleManagerProvider RoleManagerProvider;
    #endregion

    #region [ CTor ]
    public RoleDataProvider(IRoleManagerProvider roleManagerProvider)
    {
        RoleManagerProvider = roleManagerProvider;
    }
    #endregion
}