using CoreUserRole = IdentitySystem.Domain.UserRole;
using DTOUserRoleIn = IdentitySystem.Application.InputUserRoleDTO;
using DTOUserRoleOut = IdentitySystem.Application.OutputUserRoleDTO;

namespace IdentitySystem.ServiceProvider;

public class UserRoleServiceProvider : ServiceProviderBase<DTOUserRoleOut, DTOUserRoleIn, CoreUserRole>, IUserRoleServiceProvider
{
    public UserRoleServiceProvider(IUserRoleDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
