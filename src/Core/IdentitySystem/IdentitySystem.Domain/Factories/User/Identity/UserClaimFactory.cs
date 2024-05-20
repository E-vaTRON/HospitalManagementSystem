namespace IdentitySystem.Domain;

public class UserClaimFactory
{
    public static UserClaim Create()
    {
        return new UserClaim();
    }
    public static UserClaim Create(string userId, string claimType, string claimValue)
    {
        return new UserClaim()
        {
            UserId = userId,
            ClaimType = claimType,
            ClaimValue = claimValue
        };
    }
}
