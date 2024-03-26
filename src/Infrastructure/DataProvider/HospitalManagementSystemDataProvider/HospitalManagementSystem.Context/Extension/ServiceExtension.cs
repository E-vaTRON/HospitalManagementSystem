using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void HospitalManagementSystemDataBaseContextProviders(this IServiceCollection services, IConfiguration configuration)
    {
        services.HospitalManagementSystemSqlServerDataProviders<HospitalManagementSystemDbContext>(configuration);

        // Providers
        services.HospitalManagementSystemDataProviders<HospitalManagementSystemDbContext>();
    }
    #endregion
}
