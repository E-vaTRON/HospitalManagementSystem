using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleDataProvider : RoleManager<CoreRole>, IRoleManagerProvider<CoreRole, string>
{
    #region [ CTor ]
    public RoleDataProvider( RoleStoreProvider store, 
                             IEnumerable<IRoleValidator<CoreRole>> roleValidators, 
                             ILookupNormalizer keyNormalizer, 
                             IdentityErrorDescriber errors, 
                             ILogger<RoleManager<CoreRole>> logger )
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }
    #endregion
}