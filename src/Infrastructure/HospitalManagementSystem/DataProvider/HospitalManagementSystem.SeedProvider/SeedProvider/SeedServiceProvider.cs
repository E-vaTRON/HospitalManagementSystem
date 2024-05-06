namespace HospitalManagementSystem.DataProvider;

public class SeedServiceProvider : ISeedProvider
{
    #region [ Fields ]
    private readonly DataContext DataProviders;
    private readonly HospitalManagementSystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public SeedServiceProvider( DataContext dataProviders,
                         IDbContextFactory<HospitalManagementSystemDbContext> dbContextFactory)
    {
        DataProviders = dataProviders;
        DbContext = dbContextFactory.CreateDbContext();
    }
    #endregion

    #region [ Methods ]
    public async Task EnsureDatabaseAsync(Action action = null!)
    {
        if (action != null)
        {
            action.Invoke();
        }
        await DbContext.Database.EnsureCreatedAsync();
    }

    public async Task DropDatabaseAsync(Action action = null!)
    {
        if (action != null)
        {
            action.Invoke();
        }

        await DbContext.Database.EnsureDeletedAsync();
    }

    public Task ClearDatabaseAsync()
    {
        throw new NotImplementedException();
    }

    public Task SeedDatabaseAsync()
    {
        throw new NotImplementedException();
    }
    #endregion
}
