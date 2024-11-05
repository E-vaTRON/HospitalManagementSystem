namespace IdentitySystem.Domain;

public class RoleClaimFactory
{
    public static RoleClaim Create()
    {
        return new RoleClaim();
    }

    public static RoleClaim Create(int id, string claimType, string claimValue)
    {
        return new RoleClaim()
        {
            Id = id,
            ClaimType = claimType,
            ClaimValue = claimValue
        };
    }
}
