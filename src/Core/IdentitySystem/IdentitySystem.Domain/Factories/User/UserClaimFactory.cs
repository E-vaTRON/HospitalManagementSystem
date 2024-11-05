namespace IdentitySystem.Domain;

public class UserClaimFactory
{
    public static UserClaim Create()
    {
        return new UserClaim();
    }
    public static UserClaim Create(int id, string claimType, string claimValue)
    {
        return new UserClaim()
        {
            Id = id,
            ClaimType = claimType,
            ClaimValue = claimValue
        };
    }
}
