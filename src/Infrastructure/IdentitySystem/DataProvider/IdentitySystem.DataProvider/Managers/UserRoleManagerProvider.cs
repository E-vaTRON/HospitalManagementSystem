using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;

namespace IdentitySystem.DataProvider;

public class UserRoleManagerProvider : IUserRoleManagerProvider
{
    #region [ Field ]
    public UserRoleStoreProvider StoreProvider { get; set; }
    #endregion

    #region [ CTor ]
    public UserRoleManagerProvider(UserRoleStoreProvider storeProvider)
    {
        StoreProvider = storeProvider;
    }
    #endregion
}
