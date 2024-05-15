namespace HospitalManagementSystem.DataProvider;

public static class HostExtensions
{
    #region [ Public Methods - Use ]
    public static void UseInMemoryDataProviders(this IHost host)
    {
        var database = host.Services.GetService<ISeedProvider>();
        database?.EnsureDatabaseAsync().Wait();
        database?.SeedDatabaseAsync().Wait();
    }
    #endregion
}
