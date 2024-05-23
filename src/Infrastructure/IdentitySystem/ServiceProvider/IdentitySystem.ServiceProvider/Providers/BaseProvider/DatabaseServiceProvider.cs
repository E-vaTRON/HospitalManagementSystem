namespace IdentitySystem.ServiceProvider;

public class DatabaseServiceProvider : IDatabaseServiceProvider
{
    #region [ Field ]
    protected DatabaseDataProvider DataProvider { get; set; }
    #endregion

    #region [ CTor ]
    public DatabaseServiceProvider(DatabaseDataProvider dataProvider)
    {
        this.DataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    public Task BeginTransactionAsync(CancellationToken cancellationToken)
        => DataProvider.BeginTransactionAsync(cancellationToken);

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
        => DataProvider.CommitTransactionAsync(cancellationToken);
    #endregion
}
