namespace IdentitySystem.Application;

public interface IUserDataProvider : IUserContractBase<User, string>
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);

    Task CommitTransactionAsync(CancellationToken cancellationToken);
}
