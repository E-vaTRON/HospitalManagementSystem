namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtensions
{
    #region [ Public Methods - Add ]

    public static void AddHospitalManagementSystemSeedDataProviders(this IServiceCollection services,string databaseName = "HospitalDataBase") 
    {
        services.AddTransient<ISeedProvider, SeedServiceProvider>();
    }
    #endregion
}