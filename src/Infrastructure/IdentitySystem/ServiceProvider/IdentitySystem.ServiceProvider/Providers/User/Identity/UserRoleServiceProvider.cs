using CoreUserRole = IdentitySystem.Domain.UserRole;
using DTOUserRole = IdentitySystem.Application.UserRoleDTO;

namespace IdentitySystem.ServiceProvider;

public class UserRoleServiceProvider : IdentityServiceProviderBase<DTOUserRole, CoreUserRole>,  IUserRoleServiceProvider
{
    #region [ Field ]
    private readonly IUserRoleDataProvider DataProvider;
    #endregion

    #region [ CTor ]
    public UserRoleServiceProvider(IUserRoleDataProvider dataProvider, IMapper mapper) : base(mapper)
    {
        DataProvider = dataProvider;
    }
    #endregion
}
