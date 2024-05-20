using CoreUserClaim = IdentitySystem.Domain.UserClaim;
using DTOUserClaim = IdentitySystem.Application.UserClaimDTO;

namespace IdentitySystem.ServiceProvider;

public class UserClaimServiceProvider : ServiceProviderIntBase<DTOUserClaim, CoreUserClaim>, IUserClaimServiceProvider
{
    #region [ CTor ]
    public UserClaimServiceProvider(IUserClaimDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}
