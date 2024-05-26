using CoreRoleClaim = IdentitySystem.Domain.RoleClaim;
using DTORoleClaimIn = IdentitySystem.Application.InputRoleClaimDTO;
using DTORoleClaimOut = IdentitySystem.Application.OutputRoleClaimDTO;

namespace IdentitySystem.ServiceProvider;

public class RoleClaimServiceProvider : ServiceProviderIntBase<DTORoleClaimOut, DTORoleClaimIn, CoreRoleClaim>, IRoleClaimServiceProvider
{
    public RoleClaimServiceProvider(IRoleClaimDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}