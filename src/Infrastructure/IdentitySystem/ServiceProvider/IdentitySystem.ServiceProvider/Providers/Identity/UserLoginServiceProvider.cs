using CoreUserLogin = IdentitySystem.Domain.UserLogin;
using DTOUserLogin = IdentitySystem.Application.UserLoginDTO;

namespace IdentitySystem.ServiceProvider;

public class UserLoginServiceProvider : ServiceProviderBase<DTOUserLogin, CoreUserLogin>, IUserLoginServiceProvider
{
    public UserLoginServiceProvider(IUserLoginDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
