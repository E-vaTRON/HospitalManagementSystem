namespace IdentitySystem.Application;

public interface IUserRoleContractBase<TUserRole, TKey>
    where TUserRole : class
    where TKey : IEquatable<TKey>
{
}
