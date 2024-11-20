namespace IdentitySystem.Domain;

public static class RoleExtensions
{
    #region [ Private Methods ]
    private static Role AddUserRole(this Role role, UserRole userRole)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userRole));

        if (role.UserRoles.Any(x => x.Id == userRole.Id))
        {
            return role;
        }

        userRole.RoleId = role.Id;
        userRole.Role = role;
        role.UserRoles.Add(userRole);
        return role;
    }

    private static Role AddRoleClaim(this Role role, RoleClaim roleClaim)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(roleClaim));

        if (role.RoleClaims.Any(x => x.Id == roleClaim.Id))
        {
            return role;
        }

        roleClaim.RoleId = role.Id;
        roleClaim.Role = role;
        role.RoleClaims.Add(roleClaim);
        return role;
    }
    #endregion

    #region [ Public Methods ]
    public static Role AddUserRole(this Role role)
    {
        return role.AddUserRole(UserRoleFactory.Create());
    }

    public static Role AddRoleClaim(this Role role)
    {
        return role.AddRoleClaim(RoleClaimFactory.Create());
    }

    public static Role AddRoleClaim(this Role role, int id, string claimType, string claimValue)
    {
        return role.AddRoleClaim(RoleClaimFactory.Create(id, claimType, claimValue));
    }

    public static Role RemoveRelated(this Role role)
    {
        role.UserRoles.Clear();
        role.RoleClaims.Clear();
        return role;
    }
    #endregion
}
