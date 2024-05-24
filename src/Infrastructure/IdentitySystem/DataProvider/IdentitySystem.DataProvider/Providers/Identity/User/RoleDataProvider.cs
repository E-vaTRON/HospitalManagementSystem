using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleDataProvider : IRoleDataProvider
{
    #region [ Field ]
    private readonly IRoleManagerProvider RoleManagerProvider;
    #endregion

    #region [ CTor ]
    public RoleDataProvider(IRoleManagerProvider roleManagerProvider)
    {
        RoleManagerProvider = roleManagerProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Set ]
    public async Task<IdentityResult> SetRoleNameAsync(CoreRole role, string roleName)
        => await RoleManagerProvider.SetRoleNameAsync(role, roleName);
    #endregion

    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(CoreRole role)
        => await RoleManagerProvider.CreateAsync(role);
    #endregion

    #region [ Check ]
    public async Task<bool> RoleExistsAsync(string roleName)
        => await RoleManagerProvider.RoleExistsAsync(roleName);
    #endregion

    #region [ Read ]
    public IQueryable<CoreRole> FindAll(Expression<Func<CoreRole, bool>>? predicate = null)
        => RoleManagerProvider.FindAll(predicate);

    public async Task<IReadOnlyCollection<CoreRole>> FindByMultipleGuidsAsync(string[] userIds)
        => await RoleManagerProvider.FindByMultipleGuidsAsync(userIds);

    public async Task<CoreRole?> FindByIdAsync(string roleId)
        => await RoleManagerProvider.FindByIdAsync(roleId);

    public async Task<CoreRole?> FindByNameAsync(string normalizedRoleName)
        => await RoleManagerProvider.FindByNameAsync(normalizedRoleName);
    #endregion

    #region [ Update ]
    public async Task<IdentityResult> UpdateAsync(CoreRole role)
        => await RoleManagerProvider.UpdateAsync(role);
    #endregion

    #region [ Delete ]
    public async Task<IdentityResult> DeleteAsync(CoreRole role)
        => await RoleManagerProvider.DeleteAsync(role);
    #endregion

    #region [ Claim ]
    public async Task<IList<Claim>> GetClaimsAsync(CoreRole role)
        => await RoleManagerProvider.GetClaimsAsync(role);

    public async Task<IdentityResult> AddClaimAsync(CoreRole role, Claim claim)
        => await RoleManagerProvider.AddClaimAsync(role, claim);

    public async Task<IdentityResult> RemoveClaimAsync(CoreRole role, Claim claim)
        => await RoleManagerProvider.RemoveClaimAsync(role, claim);
    #endregion
    #endregion
}