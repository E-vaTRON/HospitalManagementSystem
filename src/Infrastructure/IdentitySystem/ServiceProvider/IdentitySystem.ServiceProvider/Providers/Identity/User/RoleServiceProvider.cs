using CoreRole = IdentitySystem.Domain.Role;
using DTORole = IdentitySystem.Application.RoleDTO;

namespace IdentitySystem.ServiceProvider;

public class RoleServiceProvider : IdentityServiceProviderBase<DTORole, CoreRole>, IRoleServiceProvider
{
    #region [ Field ]
    private readonly IRoleDataProvider DataProvider;
    #endregion

    #region [ CTor ]
    public RoleServiceProvider(IRoleDataProvider dataProvider, IMapper mapper) : base(mapper)
    {
        DataProvider = dataProvider;
    }
    #endregion
}
