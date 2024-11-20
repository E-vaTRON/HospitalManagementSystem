namespace HospitalManagementSystem.DataProvider;

public static class HostExtensions
{
    #region [ Public Methods - Use ]
    public static void UseHMSInMemoryDataProviders(this IHost host)
    {
        //var database = host.Services.GetService<ISeedProvider>();
        using (var scope = host.Services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<ISeedDataProvider>();
            try
            {
                database?.EnsureDatabaseAsync().Wait();
                database?.SeedDatabaseAsync().Wait();
            }
            catch (AggregateException aggException)
            {
                foreach (var exception in aggException.InnerExceptions)
                {
                    // Log or handle each exception
                    Debug.WriteLine($"An error occurred: {exception.Message}");
                    Debug.WriteLine(exception.StackTrace);
                }
                throw;
            }
        }
    }
    #endregion
}