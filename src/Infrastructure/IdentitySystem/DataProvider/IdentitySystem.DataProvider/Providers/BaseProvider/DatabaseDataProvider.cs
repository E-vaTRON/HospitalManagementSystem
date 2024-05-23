namespace IdentitySystem.DataProvider;

public class DatabaseDataProvider : IDatabaseDataProvider
{
    #region [ Field ]
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public DatabaseDataProvider(IdentitySystemDbContext dbContext)
    {
        DbContext = dbContext;
    }
    #endregion

    #region [ Methods ]
    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        await DbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        var transaction = DbContext.Database.CurrentTransaction;
        if (transaction != null)
        {
            await transaction.CommitAsync(cancellationToken);
        }
    }
    #endregion
}
