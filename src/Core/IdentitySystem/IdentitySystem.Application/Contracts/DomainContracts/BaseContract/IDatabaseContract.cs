namespace IdentitySystem.Application;

public interface IDatabaseContract
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);

    Task CommitTransactionAsync(CancellationToken cancellationToken);
}
