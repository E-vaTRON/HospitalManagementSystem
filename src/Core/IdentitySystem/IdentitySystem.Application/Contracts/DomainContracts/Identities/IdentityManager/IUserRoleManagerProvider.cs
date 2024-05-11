namespace IdentitySystem.Application;

public interface IUserRoleManagerProvider<TUserRole, TKey>
    where TUserRole : IdentityUserRole<TKey>
    where TKey : IEquatable<TKey>
{
}
