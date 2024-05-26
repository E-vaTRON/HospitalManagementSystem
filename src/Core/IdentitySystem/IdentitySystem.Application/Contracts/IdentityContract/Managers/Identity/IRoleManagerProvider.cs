namespace IdentitySystem.Application;

public interface IRoleManagerProvider : IIdentityManagerProviderBase<Role, string>
{
    #region [ Set ]
    Task<IdentityResult> SetRoleNameAsync(Role role, string roleName);
    #endregion

    #region [ Check ]
    Task<bool> RoleExistsAsync(string roleName);
    #endregion
}