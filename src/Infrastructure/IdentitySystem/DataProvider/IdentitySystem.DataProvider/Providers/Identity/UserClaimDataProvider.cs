using CoreUserClaim = IdentitySystem.Domain.UserClaim;
using DataUserClaim = IdentitySystem.DataProvider.UserClaim;

namespace IdentitySystem.DataProvider.Providers.User;

public class UserClaimDataProvider : DataProviderIntBase<CoreUserClaim, DataUserClaim>, IUserClaimDataProvider
{
    public UserClaimDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
