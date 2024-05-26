namespace IdentitySystem.Application;

public interface IRoleServiceProvider : IIdentityServiceProviderBase<OutputRoleDTO, InputRoleDTO, string>
{
    #region [ Set ]
    Task<IdentityResult> SetRoleNameAsync(InputRoleDTO role, string roleName);
    #endregion

    #region [ Check ]
    Task<bool> RoleExistsAsync(string roleName);
    #endregion
}
