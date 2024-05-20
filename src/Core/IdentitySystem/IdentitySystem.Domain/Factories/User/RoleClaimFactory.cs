namespace IdentitySystem.Domain;

public class RoleClaimFactory
{
    public static RoleClaim Create()
    {
        return new RoleClaim();
    }

    public static RoleClaim Create(string roleId, string claimType, string claimValue)
    {
        return new RoleClaim()
        {
            RoleId = roleId,
            ClaimType = claimType,
            ClaimValue = claimValue
        };
    }
}
