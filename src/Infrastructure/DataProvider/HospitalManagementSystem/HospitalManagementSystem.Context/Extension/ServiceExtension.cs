namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataBaseContextProviders(this IServiceCollection services)
    {
        services.AddSingleton<HospitalManagementSystemDbContext>(); // Add this   
    }
    #endregion
}
