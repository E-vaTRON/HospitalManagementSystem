
namespace IdentitySystem.Application;

public class RoleManagerProvider : RoleManager<Role>
{
    public RoleManagerProvider( IRoleStore<Role> store, 
                                IEnumerable<IRoleValidator<Role>> roleValidators, 
                                ILookupNormalizer keyNormalizer, 
                                IdentityErrorDescriber errors, 
                                ILogger<RoleManager<Role>> logger ) 
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }
}