using CoreRoleClaim = IdentitySystem.Domain.RoleClaim;
using DataRoleClaim = IdentitySystem.DataProvider.RoleClaim;

namespace IdentitySystem.DataProvider;

public class RoleClaimDataProvider : DataProviderIntBase<CoreRoleClaim, DataRoleClaim>, IRoleClaimDataProvider
{
    public RoleClaimDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
