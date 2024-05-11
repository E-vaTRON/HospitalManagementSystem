namespace IdentitySystem.Application;

public class UserRoleDataProvider<TUserRole, TKey>
    where TUserRole : IdentityUserRole<TKey>
    where TKey : IEquatable<TKey>
{
}