namespace IdentitySystem.Domain;

public static class RoleFactory
{
    public static Role Create()
    {
        return new Role();
    }

    public static Role Create(string roleName, bool isDeleted, DateTime createdOn, DateTime? lastUpdatedOn, DateTime? deleteOn)
    {
        return new Role()
        {
            Name = roleName,
            IsDeleted = isDeleted,
            CreatedOn = createdOn,
            LastUpdatedOn = lastUpdatedOn,
            DeleteOn = deleteOn
        };
    }
}