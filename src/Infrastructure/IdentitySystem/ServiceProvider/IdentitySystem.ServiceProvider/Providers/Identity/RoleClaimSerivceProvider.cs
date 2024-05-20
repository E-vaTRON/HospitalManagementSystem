using CoreRoleClaim = IdentitySystem.Domain.RoleClaim;
using DTORoleClaim = IdentitySystem.Application.RoleClaimDTO;


namespace IdentitySystem.ServiceProvider;

public class RoleClaimSerivceProvider : ServiceProviderIntBase<DTORoleClaim, CoreRoleClaim>, IRoleClaimSerivceProvider
{
    #region [ CTor ]
    public RoleClaimSerivceProvider(IRoleClaimDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}