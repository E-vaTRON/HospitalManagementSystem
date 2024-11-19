namespace HospitalManagementSystem.DataProvider;

public static class HostExtensions
{
    #region [ Public Methods - Use ]
    public static void UseHMSInMemoryDataProviders(this IHost host)
    {
        //var database = host.Services.GetService<ISeedProvider>();
        using (var scope = host.Services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<ISeedProvider>();
            try
            {
                database?.EnsureDatabaseAsync().Wait();
                database?.SeedDatabaseAsync().Wait();
            }
            catch (AggregateException aggEx)
            {
                foreach (var ex in aggEx.InnerExceptions)
                {
                    // Log or handle each exception
                    Debug.WriteLine($"An error occurred: {ex.Message}");
                    Debug.WriteLine(ex.StackTrace);
                }
                throw;
            }
        }
    }
    #endregion
}