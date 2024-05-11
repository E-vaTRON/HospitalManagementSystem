namespace IdentitySystem.Application;

public interface IRoleManagerProvider<TRole, TKey>
    where TRole : IdentityRole<TKey>
    where TKey : IEquatable<TKey>
{
    
}