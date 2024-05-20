using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;

namespace IdentitySystem.DataProvider;

public class UserRoleDataProvider : DataProviderBase<CoreUserRole, DataUserRole>, IUserRoleDataProvider
{
    #region [ CTor ]
    public UserRoleDataProvider(IdentitySystemDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    #endregion
}