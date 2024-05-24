using IdentitySystem.Domain;
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
        => Roles.Where(u => !u.IsDeleted)
                .WhereIf(predicate != null, predicate!);

    public async Task<IReadOnlyCollection<CoreRole>> FindByMultipleGuidsAsync(string[] roleIds)
    {
        var roleIdsSet = new HashSet<string>(roleIds);
        var roles = await Roles.Where(u => roleIdsSet.Contains(u.Id)).ToListAsync(CancellationToken);
        return roles.ToList().AsReadOnly();
    }
    #endregion

}
