namespace IdentitySystem.Domain;

public static class RoleFactory
{
    public static Role Create()
    {
        return new Role();
    }

    public static Role Create(string roleName, string normalizedName, string concurrencyStamp)
    {
        return new Role()
        {
            Name = roleName,
            NormalizedName = normalizedName,
            ConcurrencyStamp = concurrencyStamp
            //CreatedOn = DateTime.UtcNow,
        };
    }
}