using CoreUserToken = IdentitySystem.Domain.UserLogin;
using DataUserToken = IdentitySystem.DataProvider.UserLogin;

namespace IdentitySystem.DataProvider;

public class UserLoginDataProvider : DataProviderBase<CoreUserToken, DataUserToken>, IUserLoginDataProvider
{
    public UserLoginDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
