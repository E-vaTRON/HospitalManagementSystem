using CoreUserRole = IdentitySystem.Domain.UserRole;
using DTOUserRole = IdentitySystem.Application.UserRoleDTO;

namespace IdentitySystem.ServiceProvider;

public class UserRoleServiceProvider : ServiceProviderBase<DTOUserRole, CoreUserRole>,  IUserRoleServiceProvider
{
    #region [ CTor ]
    public UserRoleServiceProvider(IUserRoleDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}
