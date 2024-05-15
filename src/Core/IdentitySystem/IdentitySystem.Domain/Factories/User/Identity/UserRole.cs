namespace IdentitySystem.Domain;

public static class UserRoleFactory
{
    public static UserRole Create()
    {
        return new UserRole();
    }

    public static UserRole Create(string userId, string roleId)
    {
        return new UserRole()
        {
            UserId = userId,
            RoleId = roleId
        };
    }
}