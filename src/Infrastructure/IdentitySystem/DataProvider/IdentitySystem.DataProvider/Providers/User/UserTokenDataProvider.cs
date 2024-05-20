using CoreUserToken = IdentitySystem.Domain.UserToken;
using DataUserToken = IdentitySystem.DataProvider.UserToken;

namespace IdentitySystem.DataProvider;

public class UserTokenDataProvider : DataProviderBase<CoreUserToken, DataUserToken>, IUserTokenDataProvider
{
    public UserTokenDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}

