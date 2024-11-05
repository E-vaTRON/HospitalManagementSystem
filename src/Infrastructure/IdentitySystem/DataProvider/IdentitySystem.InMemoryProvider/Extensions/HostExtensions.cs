namespace IdentitySystem.DataProvider;

public static class HostExtensions
{
    #region [ Public Methods - Use ]
    public static void UseISInMemoryDataProviders(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<ISeedProvider>();
            database?.EnsureDatabaseAsync().Wait();
            database?.SeedDatabaseAsync().Wait();
        }
    }
    #endregion
}
