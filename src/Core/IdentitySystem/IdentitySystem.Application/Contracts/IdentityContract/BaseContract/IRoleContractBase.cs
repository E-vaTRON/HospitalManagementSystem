namespace IdentitySystem.Application;

public interface IRoleContractBase<TRole, TKey>
    where TRole : class
    where TKey : IEquatable<TKey>
{
}
