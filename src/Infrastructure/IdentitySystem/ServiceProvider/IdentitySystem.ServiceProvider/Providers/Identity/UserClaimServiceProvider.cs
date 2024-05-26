using CoreUserClaim = IdentitySystem.Domain.UserClaim;
using DTOUserClaimIn = IdentitySystem.Application.InputUserClaimDTO;
using DTOUserClaimOut = IdentitySystem.Application.OutputUserClaimDTO;

namespace IdentitySystem.ServiceProvider;

public class UserClaimServiceProvider : ServiceProviderIntBase<DTOUserClaimOut, DTOUserClaimIn, CoreUserClaim>, IUserClaimServiceProvider
{
    public UserClaimServiceProvider(IUserClaimDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
