namespace HospitalManagementSystem.DataProvider;

public static class HostExtensions
{
    #region [ Public Methods - Use ]
    public static void UseHMSInMemoryDataProviders(this IHost host)
    {
        //var database = host.Services.GetService<ISeedProvider>();
        //database?.EnsureDatabaseAsync().Wait();
        //database?.SeedDatabaseAsync().Wait();

        using (var scope = host.Services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<ISeedProvider>();
            database?.EnsureDatabaseAsync().Wait();
            database?.SeedDatabaseAsync().Wait();
        }
    }
    #endregion
}
