using CoreUserLogin = IdentitySystem.Domain.UserLogin;
using DTOUserLoginIn = IdentitySystem.Application.InputUserLoginDTO;
using DTOUserLoginOut = IdentitySystem.Application.OutputUserLoginDTO;

namespace IdentitySystem.ServiceProvider;

public class UserLoginServiceProvider : ServiceProviderBase<DTOUserLoginOut, DTOUserLoginIn, CoreUserLogin>, IUserLoginServiceProvider
{
    public UserLoginServiceProvider(IUserLoginDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}