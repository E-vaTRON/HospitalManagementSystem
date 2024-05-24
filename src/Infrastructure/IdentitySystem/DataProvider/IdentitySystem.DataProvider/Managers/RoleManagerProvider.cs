using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleManagerProvider : RoleManager<CoreRole>, IRoleManagerProvider
{
    #region [ CTor ]
    public RoleManagerProvider( RoleStoreProvider store, 
                                IEnumerable<IRoleValidator<CoreRole>> roleValidators, 
                                ILookupNormalizer keyNormalizer, 
                                IdentityErrorDescriber errors, 
                                ILogger<RoleManager<CoreRole>> logger )
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }

    public IQueryable<CoreRole> FindAll(Expression<Func<CoreRole, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<CoreRole>> FindByMultipleGuidsAsync(string[] userIds)
    {
        throw new NotImplementedException();
    }
    #endregion

}
