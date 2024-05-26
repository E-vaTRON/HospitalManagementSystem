using CoreUserToken = IdentitySystem.Domain.UserToken;
using DTOUserTokenIn = IdentitySystem.Application.InputUserTokenDTO;
using DTOUserTokenOut = IdentitySystem.Application.OutputUserTokenDTO;

namespace IdentitySystem.ServiceProvider;

public class UserTokenServiceProvider : ServiceProviderBase<DTOUserTokenOut, DTOUserTokenIn, CoreUserToken>, IUserTokenServiceProvider
{
    public UserTokenServiceProvider(IUserTokenDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
