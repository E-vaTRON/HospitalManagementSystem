using CoreUserToken = IdentitySystem.Domain.UserToken;
using DTOUserToken = IdentitySystem.Application.UserTokenDTO;

namespace IdentitySystem.ServiceProvider;

public class UserTokenServiceProvider : ServiceProviderBase<DTOUserToken, CoreUserToken>, IUserTokenServiceProvider
{
    public UserTokenServiceProvider(IUserTokenDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
