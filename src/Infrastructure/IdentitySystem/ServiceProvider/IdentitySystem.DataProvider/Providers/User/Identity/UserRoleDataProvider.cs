using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;

namespace IdentitySystem.DataProvider;

public class UserRoleDataProvider : IUserRoleDataProvider
{
    #region [ Field ]
    public UserRoleStoreProvider StoreProvider { get; set; }
    #endregion

    #region [ CTor ]
    public UserRoleDataProvider( UserRoleStoreProvider storeProvider)
    {
        StoreProvider = storeProvider;
    }
    #endregion
}