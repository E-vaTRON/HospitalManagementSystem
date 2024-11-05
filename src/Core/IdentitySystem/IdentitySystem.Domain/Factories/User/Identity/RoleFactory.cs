namespace IdentitySystem.Domain;

public static class RoleFactory
{
    public static Role Create()
    {
        return new Role();
    }

    public static Role Create(string roleName)
    {
        return new Role()
        {
            Name = roleName,
            CreatedOn = DateTime.UtcNow,
        };
    }
}