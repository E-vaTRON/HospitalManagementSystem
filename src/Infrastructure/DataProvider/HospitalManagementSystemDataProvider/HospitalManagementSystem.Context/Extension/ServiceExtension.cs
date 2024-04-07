namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataBaseContextProviders<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddSingleton<HospitalManagementSystemDbContext>(); // Add this   
    }
    #endregion
}
